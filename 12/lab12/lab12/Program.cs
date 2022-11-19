﻿using System;
using System.IO;
using System.IO.Compression;
namespace lab12
{
    class SVALog
    {
        string name;
        FileStream fs;
        SVALog(string _name)
        {
            name = _name;
            using (fs = new FileStream("test.txt", FileMode.OpenOrCreate))
            {
                
            }
        }

    }
    class SVADiskInfo
    {
        DriveInfo[] allDisk;
        public SVADiskInfo(DriveInfo[] _allDisk)
        {
            allDisk = _allDisk;
        }
        public void FreeSpace()
        {
            Console.WriteLine("\nFree space method");
            foreach(DriveInfo di in allDisk)
            {
                Console.WriteLine("Available Free space on drive {0}:\t{1}",di.Name,di.AvailableFreeSpace);
                Console.WriteLine("Total free space on drive {0}:\t\t{1}", di.Name, di.TotalFreeSpace);
            }
        } 
        public void DriveType()
        {
            Console.WriteLine("\nDrive type method:");
            foreach(DriveInfo di in allDisk)
            {
                Console.WriteLine("Тип диска :{0}",di.DriveType);
                Console.WriteLine("Имя файловой системы : {0}",di.DriveFormat);
                Console.WriteLine("Формат диска : {0}",di.DriveFormat);
            }
        }
        public void Drive()
        {
            Console.WriteLine("\nMethod File: ");
            foreach(DriveInfo di in allDisk)
            {
                Console.WriteLine("Name: {0} ; Size : {1}; Available volume: {2}; Volume label: {3}",di.Name,di.TotalSize,di.AvailableFreeSpace,di.VolumeLabel);
            }
        }


    }
    class SVAFileInfo
    {
        string name;
        string path;
        FileInfo fi;
        public SVAFileInfo(string _path)
        {
            path = _path;
            name = Path.GetFileName(path);
            fi = new FileInfo(path);
        }
        public void find()
        {
            Console.WriteLine("Full path to {0} : {1}",name,path);
        }
        public void inf()
        {
            Console.WriteLine("Name of file : {0}",name);
            Console.WriteLine("Extention : {0}" ,Path.GetExtension(name));
            Console.WriteLine("Size : {0}",fi.Length);
        }
        public void date()
        {
            Console.WriteLine("Creation time of file {0} : {1}",name,fi.CreationTime);
            Console.WriteLine("file modification time : {0}",File.GetLastWriteTime(path));
        }

    }
    class SVADirInfo
    {
        DirectoryInfo AllDirInfo;
        string path;
        FileInfo[] FI;
        DirectoryInfo[] DirInfoArr;
        public SVADirInfo(string _path)
        {
            string path = _path;
            AllDirInfo = new DirectoryInfo(path);
            FI = AllDirInfo.GetFiles();
            DirInfoArr = AllDirInfo.GetDirectories();
        }
        public void NumberOfFiles()
        {
            Console.WriteLine("\nNumber of file method: ");
            Console.WriteLine("Number of Files:{0}", FI.Length); 
        }
        public void CreationTime()
        {
            Console.WriteLine("\nName and creation: ");
            foreach (FileInfo tmp in FI)
            {
                Console.WriteLine("Name {0} , Creation time: {1}", tmp.Name, tmp.CreationTime);
            }
        }
        public void NumberOfSubDir()
        {
            Console.WriteLine("\nnumber of subdirectories : {0}", DirInfoArr.Length);
        }
        public void Parents()
        {
            foreach (DirectoryInfo tp in DirInfoArr)
            {
                Console.WriteLine("Parrent for {0} : {1}", tp.Name, tp.Parent);
            }
        }
    }
    class SVAFileManager
    {
        string path;
        string[] dirs;
        string[] files;
        public SVAFileManager(string _path)
        {
            path = _path;
            dirs = Directory.GetDirectories(path);
            files = Directory.GetFiles(path);
        }
        public void CreateDir()
        {
            Console.WriteLine("subdir");
            foreach (string temp in dirs)
            {
                Console.WriteLine(temp);
            }
            Console.WriteLine();

            Console.WriteLine("Files: ");
            foreach (string temp in files)
            {
                Console.WriteLine(temp);
            }
            Console.WriteLine();

            string path = @"D:\SVAInspect";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            string oldPath = @"D:\SVAInspect\SVAdirinfo.txt";
            string NewPath = @"D:\SVAInspect\NewName.txt";
            using (StreamWriter sw = File.CreateText(oldPath))
            {
                sw.Write("Files: \n");
                foreach (string temp in files)
                    sw.Write(temp+"\n");
                sw.Write("Subdirs:");
                foreach (string temp in dirs)
                    sw.Write(temp+"\n");
            }
            File.Copy(oldPath, NewPath, true);
            //File.Delete(oldPath);
        }
        public void newDir(string PathToDir,string _extencion)
        {
            string newPath = path + @"SVAFiles";
            Directory.CreateDirectory(newPath);
            DirectoryInfo di = new DirectoryInfo(PathToDir);
            FileInfo[] files = di.GetFiles();
            foreach(FileInfo temp in files)
            {
                if (temp.Extension ==_extencion)
                {
                    temp.CopyTo(newPath+$"\\{temp.Name}",true);
                }
            }
            //Directory.Move(PathToDir, @$"D:\SVAInspect\SVAFiles");            //создать папку forlab для сдачи
        }
        public void zip(string PathToDir)
        {
            string zipName = @"D:\SVAInspect\SVAFiles\ZIPForLab.zip";
            string zipFolder = @"D:\SVAFiles";
            ZipFile.CreateFromDirectory(zipFolder, zipName);                //удалить зип
            using (ZipArchive archive = ZipFile.OpenRead(zipName))
            {
                foreach(ZipArchiveEntry file in archive.Entries)
                {
                    Console.WriteLine("File Name: {0}", file.Name);
                    Console.WriteLine("File Size: {0} bytes", file.Length);
                }
            }
            using (ZipArchive archive = ZipFile.Open(zipName,ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry temp in archive.Entries)
                {
                    temp.ExtractToFile(PathToDir+@$"\{temp.Name}",true);
                }
            }




        }




    }




    class Program
    {
        static void Main(string[] args)
        {

            DriveInfo[] allDisk = DriveInfo.GetDrives();
            SVADiskInfo DI = new SVADiskInfo(allDisk);
            DI.FreeSpace();
            DI.DriveType();
            DI.Drive();


            string path = "C:\\Users\\User\\OneDrive\\Рабочий стол\\ООП\\лабораторные\\11\\lab11\\lab11\\bin\\Debug\\netcoreapp3.1";
            SVADirInfo dirInfo = new SVADirInfo(path);
            dirInfo.NumberOfFiles();
            dirInfo.CreationTime();
            dirInfo.NumberOfSubDir();
            dirInfo.Parents();

            string path2 = "C:\\Users\\User\\OneDrive\\Рабочий стол\\ticket_58061812.pdf";
            
            SVAFileInfo fileInfo = new SVAFileInfo(path2);
            fileInfo.find();
            fileInfo.inf();
            fileInfo.date();

            string disk = "D:\\";
            SVAFileManager manager = new SVAFileManager(disk);
            manager.CreateDir();
            manager.newDir(@"D:\forlab", @".txt");
            manager.zip(@"D:\SVAInspect");











        }
    }
}
