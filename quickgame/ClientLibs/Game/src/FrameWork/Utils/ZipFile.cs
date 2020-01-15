using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace Utils
{
	public class ZipClass
	{
		static ZipClass mInstance = null;

		public static ZipClass GetInstance()
		{
			if (mInstance == null)
				mInstance = new ZipClass();

			return mInstance;
		}

		#region "MD5加密"
		/// <summary>
		///32位 MD5加密
		/// </summary>
		/// <param name="str">加密字符</param>
		/// <returns></returns>
		string encrypt(string str)
		{
			string cl = str;
			string pwd = "";
			MD5 md5 = MD5.Create();
			byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
			for (int i = 0; i < s.Length; i++)
			{
				pwd = pwd + s [i].ToString("X");
			}
			return pwd;
		}
		#endregion

		public string ZipFile(string fullFilename, string password)
		{
			int extIdx = fullFilename.LastIndexOf(".");
			string encrypt_fiilename;
			if (extIdx < 0)
				encrypt_fiilename = fullFilename + ".uass";
			else
				encrypt_fiilename = fullFilename.Substring(0, extIdx) + ".uass";

			ZipOutputStream out_stream = new ZipOutputStream(File.Create(encrypt_fiilename));
			
			out_stream.SetLevel(9); // 0 - store only to 9 - means best compression
			
			out_stream.Password = encrypt(password);

			//打开压缩文件 
			FileStream in_stream = File.OpenRead(fullFilename);
				
			byte[] buffer = new byte[in_stream.Length];
			in_stream.Read(buffer, 0, buffer.Length);
				
			//Array arr = filename.Split('/');
			//arr.GetValue(arr.Length - 1).ToString();
			string filename = Path.GetFileName(fullFilename);
			ZipEntry entry = new ZipEntry(filename);
			entry.DateTime = DateTime.Now;
			entry.Size = in_stream.Length;

			in_stream.Close();
			out_stream.PutNextEntry(entry);
			out_stream.Write(buffer, 0, buffer.Length);

			out_stream.Finish();
			out_stream.Close();

			return encrypt_fiilename;
		}

		public void UnZipFile(string full_filename, string password)
		{
			if (!File.Exists(full_filename))
				return;

			string directoryName = Path.GetDirectoryName(full_filename);
			using (FileStream fileStreamIn = new FileStream(full_filename, FileMode.Open, FileAccess.Read))
			{
				using (ZipInputStream zipInStream = new ZipInputStream(fileStreamIn))
				{
					zipInStream.Password = encrypt(password);
					ZipEntry entry = zipInStream.GetNextEntry();
					do
					{
						using (FileStream fileStreamOut = new FileStream(directoryName + "/" + entry.Name, FileMode.Create, FileAccess.Write))
						{
							int buff_size = 2048;
							byte[] buffer = new byte[2048];
							do
							{
								buff_size = zipInStream.Read(buffer, 0, buffer.Length);
								fileStreamOut.Write(buffer, 0, buff_size);
							} while (buff_size > 0);
						}

                        // 文件读取完毕
                        if(fileStreamIn.Position >= fileStreamIn.Length)
                        {
                            break;
                        }
					} while ((entry = zipInStream.GetNextEntry()) != null);
				}
			}
		}

        public void UnZipFile(string full_filename, string unzipfile, string destDir, string password)
        {
            if (!File.Exists(full_filename))
                return;

            if(!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            using (FileStream fileStreamIn = new FileStream(full_filename, FileMode.Open, FileAccess.Read))
            {
                using (ZipInputStream zipInStream = new ZipInputStream(fileStreamIn))
                {
                    zipInStream.Password = encrypt(password);
                    ZipEntry entry = zipInStream.GetNextEntry();
                    do
                    { 
                        if(!string.IsNullOrEmpty(unzipfile) && entry.Name != unzipfile)
                            continue;

                        using (FileStream fileStreamOut = new FileStream(destDir + "/" + entry.Name, FileMode.Create, FileAccess.Write))
                        {
                            int buff_size = 2048;
                            byte[] buffer = new byte[2048];
                            do
                            {
                                buff_size = zipInStream.Read(buffer, 0, buffer.Length);
                                fileStreamOut.Write(buffer, 0, buff_size);
                            } while (buff_size > 0);
                        }
                    } while ((entry = zipInStream.GetNextEntry()) != null && fileStreamIn.Position < fileStreamIn.Length);
                }
            }
        }

        /// <summary>
        /// 将zip的内存数据进行解压,并返回二进制数据(针对lua文件解压进行了优化，其他地方不能调用)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Dictionary<string, byte[]> UnZipToMemory(byte[] data, string password)
        {
            var ret = new Dictionary<string, byte[]>();
            using (var stream = new MemoryStream(data))
            {
                using (var zip_stream = new ZipInputStream(stream))
                {
                    zip_stream.Password = password;
                    var total_buffer = new byte[512 * 1024]; // 一次性分配512K内存用来解压文件，避免MemoryStream分配过多的临时内存(lua文件正常情况下不会超过512K)
                    var buffer = new byte[5 *1024]; // ZipInputStream读取一次数据的buff

                    ZipEntry entry = null;
                    while ((entry = zip_stream.GetNextEntry()) != null)
                    {
                        if (!entry.IsFile)
                            continue;

                        int cur_buff_size = 0;
                        int total_buff_size = 0;
                        while (true)
                        {
                            cur_buff_size = zip_stream.Read(buffer, 0, buffer.Length);
                            if (cur_buff_size > 0)
                            {
                                Array.Copy(buffer, 0, total_buffer, total_buff_size, cur_buff_size);
                                total_buff_size += cur_buff_size;
                            }
                            else
                                break;
                        }

                        byte[] unzip_data = new byte[total_buff_size];
                        Array.Copy(total_buffer, unzip_data, total_buff_size);

                        ret[entry.Name] = unzip_data;
                    } 
            }
            }

            return ret;
        }

		public byte[] UnZipFileToMemory(string full_filename, string password)
		{
			byte[] file_data = null;
			if (!File.Exists(full_filename))
				return null;
		
			string directoryName = Path.GetDirectoryName(full_filename);
			using (FileStream fileStreamIn = new FileStream(full_filename, FileMode.Open, FileAccess.Read))
			{
				//file_data = new byte[fileStreamIn.Length]
				using (ZipInputStream zipInStream = new ZipInputStream(fileStreamIn))
				{
					zipInStream.Password = encrypt(password);
                    ZipEntry entry = null;
                    while ((entry = zipInStream.GetNextEntry()) != null)
					{
                        using (MemoryStream fileStreamOut = new MemoryStream())
                        {
                            byte[] buffer = new byte[2048];
                            int cur_buff_size = 0;
                            //int total_buff_size = 0;
                            while (true)
                            {
                                cur_buff_size = zipInStream.Read(buffer, 0, buffer.Length);
                                //total_buff_size += cur_buff_size;
                                if (cur_buff_size > 0)
                                    fileStreamOut.Write(buffer, 0, cur_buff_size);
                                else
                                    break;
                            }

                            file_data = fileStreamOut.ToArray();
                        }
                    }
				}
			}
		
			return file_data;
		}

        /// <summary>
        /// 解压Zip文件到内存中(只解压第一个文件, 并针对表格解压进行了专门优化，其他地方不能用)
        /// </summary>
        /// <param name="full_filename"></param>
        /// <param name="password"></param>
        /// <param name="unzip_ratio"></param>
        /// <returns></returns>
        public byte[] UnZipFileToMemoryEx(string full_filename, string password)
        {
            if (!File.Exists(full_filename))
                return null;

            // 使用FileStream打开zip文件
            using (var file_stream = new FileStream(full_filename, FileMode.Open, FileAccess.Read))
            {
                // 获取ZipInputStream
                using (var zip_stream = new ZipInputStream(file_stream))
                {
                    // 字符串的md5作为密码
                    zip_stream.Password = encrypt(password);

                    // 获取zip文件的入口
                    ZipEntry entry = null;
                    while ((entry = zip_stream.GetNextEntry()) != null)
                    {
                        if (!entry.IsFile)
                            continue;

                        int total_buff_offset = 0;
                        int cur_buff_size = 0;
                        byte[] buffer = new byte[10*1024];

                        var unzip_size = entry.Size;
                        // 获取解压后的大小
                        if(unzip_size != -1 && unzip_size != 0)
                        {
                            byte[] unzip_file_data = new byte[(int)(entry.Size)];
                            while (true)
                            {
                                cur_buff_size = zip_stream.Read(buffer, 0, buffer.Length);

                                if (cur_buff_size > 0)
                                {
                                    Array.Copy(buffer, 0, unzip_file_data, total_buff_offset, cur_buff_size);
                                    total_buff_offset += cur_buff_size;
                                }
                                else
                                    break;
                            }

                            return unzip_file_data;
                        }
                        // 获取失败的时候使用MemoryStream进行数据读取
                        else
                        {
                            byte[] unzip_file_data = null;
                            using (var memory_stream = new MemoryStream())
                            {
                                while (true)
                                {
                                    cur_buff_size = zip_stream.Read(buffer, 0, buffer.Length);

                                    if (cur_buff_size > 0)
                                        memory_stream.Write(buffer, 0, cur_buff_size);
                                    else
                                        break;
                                }

                                unzip_file_data = memory_stream.ToArray();
                            }

                            return unzip_file_data;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 解压缩字节数组
        /// </summary>
        /// <param name="sourceByte">需要被解压缩的字节数组</param>
        /// <returns>解压后的字节数组</returns>
        static ICSharpCode.SharpZipLib.Zip.Compression.Inflater infla = new ICSharpCode.SharpZipLib.Zip.Compression.Inflater(true);
		public static byte[] DeCompressBytes(byte[] sourceByte, int oriLen)
		{
			byte[] unCompressData = null;

			using (MemoryStream bytesStreamIn = new MemoryStream(sourceByte))
			{
				using (InflaterInputStream zipInStream = new InflaterInputStream(bytesStreamIn, infla, (int)(oriLen * 1.2f)))
				{
					using (MemoryStream bytesStreamOut = new MemoryStream())
					{
						byte[] buffer = new byte[2048];
						int cur_buff_size = 0;
						while(true)
						{
							cur_buff_size = zipInStream.Read(buffer, 0, buffer.Length);
                            if (cur_buff_size > 0)
                                bytesStreamOut.Write(buffer, 0, cur_buff_size);
                            else
                                break;
						}
						
						unCompressData = bytesStreamOut.ToArray();
						zipInStream.Close();
						bytesStreamOut.Close();
					}
				}
			}

			return unCompressData;
		}
	}

	/* public void ZipFile(string FileToZip, string ZipedFile, int CompressionLevel, int BlockSize)
		{
			if (!System.IO.File.Exists(FileToZip))
			{
				throw new System.IO.FileNotFoundException("The specified file " + FileToZip + " could not be found. Zipping aborderd");
			}
			
			System.IO.FileStream in_stream = new System.IO.FileStream(FileToZip, System.IO.FileMode.Open, System.IO.FileAccess.Read);

			System.IO.FileStream ZipFile = System.IO.File.Create(ZipedFile);
			ZipOutputStream out_stream = new ZipOutputStream(ZipFile);
			ZipEntry ZipEntry = new ZipEntry("ZippedFile");
			out_stream.PutNextEntry(ZipEntry);
			out_stream.SetLevel(CompressionLevel);

			byte[] buffer = new byte[BlockSize];
			System.Int32 size = in_stream.Read(buffer, 0, buffer.Length);
			out_stream.Write(buffer, 0, size);

			try
			{
				while (size < in_stream.Length)
				{
					int sizeRead = in_stream.Read(buffer, 0, buffer.Length);
					out_stream.Write(buffer, 0, sizeRead);
					size += sizeRead;
				}
			} catch (System.Exception ex)
			{
				throw ex;
			}

			out_stream.Finish();
			out_stream.Close();

			in_stream.Close();
		}
	*/

	/*public void ZipFileMain(string[] args, string password)
		{
			string[] filenames = Directory.GetFiles(args[0]);
			
			ZipOutputStream s = new ZipOutputStream(File.Create(args[1]));
			
			s.SetLevel(6); // 0 - store only to 9 - means best compression 
			
			s.Password = md5.encrypt(password);
			
			foreach (string file in filenames)
			{
				//打开压缩文件 
				FileStream fs = File.OpenRead(file);
				
				byte[] buffer = new byte[fs.Length];
				fs.Read(buffer, 0, buffer.Length);
				
				Array arr = file.Split('\\');
				string le = arr.GetValue(arr.Length - 1).ToString();
				ZipEntry entry = new ZipEntry(le);
				entry.DateTime = DateTime.Now;
				entry.Size = fs.Length;
				fs.Close();
				s.PutNextEntry(entry);
				s.Write(buffer, 0, buffer.Length);
			}
			s.Finish();
			s.Close();
		}*/
	
	/*class UnZipClass
	{
		public void UnZip(string[] args, string password)
		{
			string directoryName = Path.GetDirectoryName(args [1]);
			using (FileStream fileStreamIn = new FileStream(args[0], FileMode.Open, FileAccess.Read))
			{
				using (ZipInputStream zipInStream = new ZipInputStream(fileStreamIn))
				{
					zipInStream.Password = md5.encrypt(password);
					ZipEntry entry = zipInStream.GetNextEntry();
					do
					{
						using (FileStream fileStreamOut = new FileStream(directoryName + @"\" + entry.Name, FileMode.Create, FileAccess.Write))
						{
							
							int size = 2048;
							byte[] buffer = new byte[2048];
							do
							{
								size = zipInStream.Read(buffer, 0, buffer.Length);
								fileStreamOut.Write(buffer, 0, size);
							} while (size > 0);
						}
					} while ((entry = zipInStream.GetNextEntry()) != null);
				}
			}
		}
	}*/
}

