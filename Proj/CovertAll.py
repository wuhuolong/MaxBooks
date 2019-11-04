import xlrd
import shutil
import sys
import os
import logging
import traceback

print(os.getcwd())
xls_path = os.getcwd()+"/xls/"
for root,dirs,files in os.walk(xls_path):
    for dir in dirs:
        print(os.path.join(root,dir))
    for file in files:
        command = "covertone "+file.split(".")[0]
        print(command)
        os.system(command)
#后处理资源，把资源自动到工程目录里
cs_spath = os.getcwd()+"/gen/proto2cs"
cs_fpath = "../Client/UnityProj/Assets/Scripts/Gen"

for cs_fpath,dirs,files in os.walk(cs_fpath):
    for file in files:
        if os.path.splitext(file)[-1] == ".cs":
            os.remove(os.path.join(cs_fpath,file))

for cs_spath,dirs,files in os.walk(cs_spath):
    for file in files:
        if os.path.splitext(file)[-1] == ".cs":
            shutil.copyfile(os.path.join(cs_spath,file),os.path.join(cs_fpath,file))


bin_spath = os.getcwd()+"/gen/bin"
bin_fpath = "../Client/UnityProj/Assets/Data/DataConfig"

for bin_spath,dirs,files in os.walk(bin_spath):
    for file in files:
        if os.path.splitext(file)[-1] == ".bin":
            shutil.move(os.path.join(bin_spath,file),os.path.join(bin_fpath,file))