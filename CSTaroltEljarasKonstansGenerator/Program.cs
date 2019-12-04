using d7p4n4Namespace.Final.Class;
using System;
using System.IO;

namespace CSTaroltEljarasKonstansGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Deserializer deserializer = new Deserializer();

            try
            {
                string[] filesMethods =
                    Directory.GetFiles("d:\\Server\\Visual_studio\\output_Xmls\\StorProcsMethods\\", "*.xml", SearchOption.TopDirectoryOnly);

                string[] filesArgs =
                    Directory.GetFiles("d:\\Server\\Visual_studio\\output_Xmls\\StorProcs\\", "*.xml", SearchOption.TopDirectoryOnly);

                Console.WriteLine(filesMethods.Length);

                foreach (var _file in filesArgs)
                {
                    TaroltEljaras ujTaroltEljaras = new TaroltEljaras();
                    TaroltEljaras ujTaroltEljarasMethods = new TaroltEljaras();
                    string _filename = Path.GetFileNameWithoutExtension(_file);
                    Console.WriteLine(_filename);
                    foreach(var fileMethod in filesMethods)
                    {
                        string muvFileName = Path.GetFileNameWithoutExtension(fileMethod);
                        string muvelet = muvFileName.Substring(0, muvFileName.IndexOf("@"));
                        if (_filename.ToLower().Equals(muvelet.ToLower()))
                        {
                            Console.WriteLine(">>PAIR: " + _filename + " " + muvelet);
                            string textFileArgs = Path.Combine("d:\\Server\\Visual_studio\\output_Xmls\\StorProcs\\", _filename + ".xml");
                            string textFileMethods = Path.Combine("d:\\Server\\Visual_studio\\output_Xmls\\StorProcsMethods\\", muvFileName + ".xml");

                            string textArgs = File.ReadAllText(textFileArgs);
                            string textMethods = File.ReadAllText(textFileMethods);

                            ujTaroltEljaras = deserializer.deser(textArgs);
                            ujTaroltEljarasMethods = deserializer.deser(textMethods);
                            Generator.generateClass("d:\\Server\\Visual_studio\\AK\\outputTaroltEljaras\\", ujTaroltEljaras, ujTaroltEljarasMethods);
                        }

                    }
                    

                }
            }
            catch (Exception _exception)
            {
                Console.WriteLine(_exception.StackTrace);
            }
        }
    }
}

