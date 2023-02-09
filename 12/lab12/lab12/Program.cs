using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
namespace lab12
{
    class SVALog
    {
        string path = @"D:\SVAInspect\SVAFiles\SVALog.txt";
        StreamWriter SW;
        StreamReader SR;
        public void write(string information)
        {
            using (SW = new StreamWriter(path,true,Encoding.Default))
            {
                SW.WriteLine(information);          //нельзя записывать в private SW
            }
        }
        public void Count()
        {
            int count;
            using (SR= new StreamReader(path,Encoding.Default))
            {
                count = SR.ReadToEnd().Split('\n').Where(t => t.StartsWith("Date") == true).Count();
            }
            Console.WriteLine("количество записей:{0}",count);
        }
        public void FindInf(string date,string from , string to,string key)
        {
            string res = "";

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {

                string[] infos = sr.ReadToEnd().Split('\n');
                string str = "";
                Console.WriteLine("\n\nДействия пользователя за определенный день:\n\n ");
                foreach (var s in infos)
                {
                    str += s;
                    str += '\n';
                    if (s.Contains(date))
                    {
                        while (!s.Contains("Date"))
                        {
                            str += s;
                        }
                        Console.WriteLine(str);
                        str = "";
                    }
                }
                Console.WriteLine("\n\nИнформация по ключевому слову:\n\n");
                foreach (var s in infos)
                {
                    if (s.Contains(key))
                    {
                        Console.WriteLine(s);
                    }
                }
                int k=1;
                Console.WriteLine("\n\nДействия пользователя за промежуток времени:\n\n ");
                str = "";
                foreach (var temp in infos)
                {
                    str = "";
                    if (temp.Contains(from)||temp.Contains(to))
                    {
                        Console.WriteLine(infos[k++]);
                        while (!infos[k].Contains("Date"))
                        {
                            Console.WriteLine(infos[k++]);
                        }
                        
                    }
                }
            }
        }
        public void delete(string time)
        {
            SW.Close();
            int counter = 0;
            string str = "";
            using (SR = new StreamReader(path, Encoding.Default))
            {
                string []infos=SR.ReadToEnd().Split('\n');
                for(int i=0;i<infos.Length;++i)
                {
                    if (infos[i].Contains(time))
                    {
                        int k = i + 2;
                        while (!infos[k].Contains("Date"))
                        {
                            i++;
                            k++;
                        }
                    }
                    str += infos[i];
                    str += "\n";
                }
            }
            SW = new StreamWriter(path, false, Encoding.Default);
            SW.WriteLine(str);

        }
        public void Close()
        {
            SW.Close();
        }
    }
    class SVADiskInfo
    {
        DriveInfo[] allDisk;
        public SVADiskInfo(DriveInfo[] _allDisk)
        {
            allDisk = _allDisk;
        }
        public DriveInfo[] FreeSpace()
        {
            Console.WriteLine("\nFree space method");
            foreach(DriveInfo di in allDisk)
            {
                Console.WriteLine("Available Free space on drive {0}:\t{1}",di.Name,di.AvailableFreeSpace);
                Console.WriteLine("Total free space on drive {0}:\t\t{1}", di.Name, di.TotalFreeSpace);
            }
            return allDisk;

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
        public string find()
        {
            string stroke = $"Full path to {name} : {path}";
            Console.WriteLine("Full path to {0} : {1}",name,path);
            return stroke;
        }
        public string inf()
        {
            Console.WriteLine("Name of file : {0}",name);
            Console.WriteLine("Extention : {0}" ,Path.GetExtension(name));
            Console.WriteLine("Size : {0}",fi.Length);
            string stroke = $"Name of file : {name}\nExtention : {Path.GetExtension(name)}\nSize: {fi.Length}";
            return stroke;
        }
        public string date()
        {
            Console.WriteLine("Creation time of file {0} : {1}",name,fi.CreationTime);
            Console.WriteLine("file modification time : {0}",File.GetLastWriteTime(path));
            string stroke = $"Creation time of file {name} : {fi.CreationTime}\nfile modification time : {File.GetLastWriteTime(path)}";
            return stroke;
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
        public FileInfo[] NumberOfFiles()
        {
            Console.WriteLine("\nNumber of file method: ");
            Console.WriteLine("Number of Files:{0}", FI.Length);
            return FI;
        }
        public void CreationTime()
        {
            Console.WriteLine("\nName and creation: ");
            foreach (FileInfo tmp in FI)
            {
                Console.WriteLine("Name {0} , Creation time: {1}", tmp.Name, tmp.CreationTime);
            }
        }
        public DirectoryInfo[] NumberOfSubDir()
        {
            Console.WriteLine("\nnumber of subdirectories : {0}", DirInfoArr.Length);
            return DirInfoArr;
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
            string oldPath = @"D:\SVAInspect\SVAdirinfo.txt";
            string NewPath = @"D:\SVAInspect\NewName.txt";
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
            //ZipFile.CreateFromDirectory(zipFolder, zipName);                //удалить зип
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
            SVALog Log = new SVALog();
            try
            {
                DriveInfo[] allDisk = DriveInfo.GetDrives();
                SVADiskInfo DI = new SVADiskInfo(allDisk);
                DriveInfo[] DrI = DI.FreeSpace();
                Log.write($"\nDate & Time: {DateTime.Now}\n");
                Log.write("Free space method of SVADiskInfo: ");
                foreach (var item in DrI)
                {
                    Log.write($"Available Free space on drive { item.Name}:\t{item.AvailableFreeSpace}");
                    Log.write($"Total free space on drive {item.Name}:\t\t{item.TotalFreeSpace}");
                }

                DI.DriveType();
                Log.write("Drive type method:");
                foreach (DriveInfo di in allDisk)
                {
                    Log.write($"Тип диска :{ di.DriveType}");
                    Log.write($"Имя файловой системы : {di.DriveFormat}");
                    Log.write($"Формат диска : {di.DriveFormat}");
                }

                DI.Drive();
                foreach (DriveInfo di in allDisk)
                {
                    Log.write($"Name: {di.Name} ; Size : {di.TotalSize}; Available volume: { di.AvailableFreeSpace}; Volume label: {di.VolumeLabel}");
                }


                string path = "C:\\Users\\User\\OneDrive\\Рабочий стол\\ООП\\лабораторные\\11\\lab11\\lab11\\bin\\Debug\\netcoreapp3.1";
                SVADirInfo dirInfo = new SVADirInfo(path);

                FileInfo[] FI = dirInfo.NumberOfFiles();
                Log.write("Number of file method: ");
                Log.write($"Number of Files:{FI.Length}");

                dirInfo.CreationTime();
                Log.write("Name and creation: ");
                foreach (FileInfo tmp in FI)
                {
                    Log.write($"Name { tmp.Name} , Creation time: {tmp.CreationTime}");
                }

                DirectoryInfo[] DirInfoArr = dirInfo.NumberOfSubDir();
                Log.write($"number of subdirectories : {DirInfoArr.Length}");

                dirInfo.Parents();
                foreach (DirectoryInfo tp in DirInfoArr)
                {
                    Log.write($"Parrent for {tp.Name} : { tp.Parent}");
                }

                string path2 = "C:\\Users\\User\\OneDrive\\Рабочий стол\\ticket_58061812.pdf";
                SVAFileInfo fileInfo = new SVAFileInfo(path2);
                string stroke = fileInfo.find();
                Log.write(stroke);

                string str = fileInfo.inf();
                Log.write(str);

                string temp = fileInfo.date();
                Log.write(str);

                string disk = "D:\\";
                SVAFileManager manager = new SVAFileManager(disk);
                manager.CreateDir();
                string[] dirs;
                string[] files;
                dirs = Directory.GetDirectories(@"D:\");
                files = Directory.GetFiles(@"D:\");
                Log.write("subdir");
                foreach (string t in dirs)
                {
                    Log.write(t);
                }
                Log.write("Files: ");
                foreach (string tem in files)
                {
                    Log.write(tem);
                }
                manager.newDir(@"D:\forlab", @".txt");
                Log.write("Created new Directory");
                manager.zip(@"D:\SVAInspect");
                Log.write(@"Arhivization and unpacking ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Source);
            }
            finally
            {
                Log.Close();
                Log.Count();
                Log.FindInf("20.11.2022", "3:30:00", "3:31:00", "Reflector.xml");
                Log.delete("3:38:30");
            }
        }
    }
}
