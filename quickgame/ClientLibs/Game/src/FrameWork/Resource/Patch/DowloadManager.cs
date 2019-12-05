using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SGameFirstPass
{

	public class DownloadInf
	{
		public string url_;
		public string path_;
	}
	
	public delegate void download_process(float _downloaded_size_in_kb, float _speed);
	public delegate void download_error();

	public class Dowloader
	{
		public bool is_error_ = false;
		public  IEnumerator download_files(Queue<DownloadInf> _infs, int _connections_num, download_process _download_process_cb, MonoBehaviour _mono)
		{
			is_error_ = false;
			if(_connections_num < 1)
			{
				yield break;
			}
			List<DownloadQueue> work_queue = new List<DownloadQueue>(_connections_num);
			for(int i =0; i< _connections_num; ++i)
			{
				DownloadQueue download_queue = new DownloadQueue(_infs);
				download_queue.start(_mono);
				work_queue.Add(download_queue);
			}
			while(true)
			{
				
				float total_downloaded = 0;
				float speed = 0;
				bool is_finished = true;
				foreach(DownloadQueue download_queue in work_queue)
				{
					if (!download_queue.is_finished())
					{
						is_finished = false;
					}
					if(download_queue.is_error_)
					{
						is_error_ = true;
					}
					total_downloaded += download_queue.total_bytes_;
					speed += download_queue.get_download_speed();
				}
				if(is_error_)
				{
					foreach(DownloadQueue download_queue in work_queue)
					{
						download_queue.stop();
					}
				}
				//update inf
				_download_process_cb(total_downloaded, speed);
				if(is_finished)
				{
					break;
				}
				yield return new WaitForSeconds(1);
			}
		}
	}

	public class DownloadQueue
	{
		public DownloadQueue(Queue<DownloadInf> _donwload_queue)
		{
			donwload_queue_ = _donwload_queue;
		}

		public int total_bytes_ = 0;

		private Queue<DownloadInf> donwload_queue_;
		private WWW curent_www_;
		private DownloadInf current_download_inf_;
		private float start_time_ = 0;
		private float end_time_ =0;
		private bool force_stop_ = false;
		private bool is_run_ = false;
		public bool is_error_ = false;

		
		public bool is_finished()
		{
			return !is_run_;
		}
		
		public float get_download_speed()
		{
			if(start_time_ == end_time_)
			{
				return 0;
			}
			return total_bytes_/((end_time_-start_time_));
		}
		
		
		public void start(MonoBehaviour _mono)
		{
			_mono.StartCoroutine(run());
		}
		
		public void stop()
		{
			force_stop_ = true;
		}
		
	
		private IEnumerator run()
		{
			is_run_ = true;
			start_time_ = Time.time;
			while(true)
			{
				//force stop
				if(force_stop_ || is_error_)
				{
					break;
				}
				//query done
				if(curent_www_ != null && curent_www_.isDone)
				{
					if(string.IsNullOrEmpty(curent_www_.error)==false)
					{
						donwload_queue_.Enqueue(current_download_inf_);
						Debug.Log(string.Format("error dowload  {0} because {1}", current_download_inf_.url_, curent_www_.error));
						is_error_ = true;
					}
					else
					{
						File.WriteAllBytes(current_download_inf_.path_, curent_www_.bytes);
						total_bytes_ += curent_www_.bytes.Length/1024;
						end_time_ = Time.time;
					}
					curent_www_.Dispose();
					curent_www_ = null;
					current_download_inf_ = null;
				}
				
				//add task
				if(curent_www_ == null )
				{
					if(donwload_queue_.Count >0)
					{
						DownloadInf download_inf = donwload_queue_.Dequeue();
						curent_www_ =new WWW(download_inf.url_);
						current_download_inf_ = download_inf;
					}
					else
					{
						break;
					}
				}
				yield return new WaitForEndOfFrame();
			}

			if(current_download_inf_ != null)
			{
				donwload_queue_.Enqueue(current_download_inf_);
				current_download_inf_ = null;
			}
			if(curent_www_ != null)
			{
				curent_www_.Dispose();
				curent_www_ = null;
			}
			is_run_ = false;
		}
	}
	


	public class RetryWWW 
	{
		public WWW www_;
		private string url_;
		private bool finished_;
		private MessageBoxUI message_box_ui_;
		private MonoBehaviour mono_;
		public IEnumerator download(string _url, MessageBoxUI _message_box_ui, MonoBehaviour _mono)
		{
			finished_ = false;
			url_ = _url;
			message_box_ui_= _message_box_ui;
			mono_ = _mono;
			www_ = new WWW(url_);
			yield return www_;
			if (string.IsNullOrEmpty(www_.error)==false)
			{
				Debug.Log(www_.error);
				www_.Dispose();
                // 暂时屏蔽
				/*Button.ButtonClickedEvent click_event = new Button.ButtonClickedEvent();
				click_event.AddListener(retry);
				message_box_ui_.Show("网络出现问题，点击可以重试", "重试连接", click_event);*/
				while(!finished_)
				{
					yield return new WaitForEndOfFrame();
				}
			}
			else
			{
				finished_ = true;
			}
		}
		
		public void destroy()
		{
			if(www_ != null)
			{
				www_.Dispose();
			}
		}
		
		private void retry()
		{
			mono_.StartCoroutine(retry_coroutine());
		}
		
		private IEnumerator retry_coroutine()
		{
			message_box_ui_.Close();
			www_ = new WWW(url_);
			yield return www_;
			if (string.IsNullOrEmpty(www_.error)==false)
			{
				Debug.Log(www_.error);
				www_.Dispose();
                // 暂时屏蔽
				/*Button.ButtonClickedEvent click_event = new Button.ButtonClickedEvent();
				click_event.AddListener(retry);
				message_box_ui_.Show("网络出现问题，点击可以重试", "重试连接", click_event);*/
			}
			else
			{
				finished_ = true;
			}
		}
	}
}
