using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Bir sebepten ötürü Math.Atan ve Math.Atan2 fonksiyonlarının cevaplarını merak ettim.
// Ondan ötürü böyle bir program yazdım. Bu sayede nokların birbirine göre olan konumlarından
// Açısını buldum. Daha fazla detay için "iki nokta arasında vektör çizmek" veya "iki vektör arasında
// açı hesabı" konularında araştırma yaparak matematiksel detaylar hakkında bilgi sahibi olabilirisiniz.

// Program çıktısı debug klasörü altında bir .txt dosyasına kayıt ediliyor. Böylece uzun ve detaylı incelemerler
// yardımcı oluyor. 

namespace tan_Atan
{
    class Program
    {


        static void tan_hes()
        {

            //x1 ve y1 araç konumu
            //x2 ve y2 hedef konumu

            for (double x1 = -1; x1 <= 1; x1 +=0.1)
            {
                for (double y1 = -1; y1 <= 1; y1 += 0.1)
                {
                    for (double x2 = -1; x2 <= 1; x2 += 0.1)
                    {
                        for (double y2 = -1; y2 <= 1; y2 += 0.1)
                        {
                            double farkX = x2 - x1;
                            double farkY = y2 - y1;
                            double Radaci = Math.Atan2(farkY, farkX);
                            double DegAci = Radaci * 180 / Math.PI;
                            Console.WriteLine("x1= " + x1 + "   y1= " + y1 + "   x2= " + x2 + "   y2= " + y2 + "   FarkX= " + farkX + "   FarkY= " + farkY + "   RADYAN açı= " + Radaci + "   Derece Açı= " + DegAci);

                        }
                    }
                }
            }
        }
        public static void Main(string[] args)
        {

            /*
            for (int i = 0; i < 360; i++)
            {
                double radian = Math.PI * i / 180;
                Console.WriteLine("Cos( " + i + " ) = " + Math.Cos(radian).ToString());
                Console.WriteLine("Sin( " + i + " ) = " + Math.Sin(radian).ToString());
                Console.WriteLine("Tan( " + i + " ) = " + Math.Tan(radian).ToString());

            }*/
            
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            
            try
            {
                ostrm = new FileStream("./Redirect.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);
            Console.WriteLine("Satır halinde yazılan herşey txt dosyasına kayıt edilecek. ");
            Console.WriteLine("Console.Write() veya Console.WriteLine() komutlarını kullanınız.");
            Console.WriteLine("Kayıtlarınız Başlıyor. ");
            tan_hes();
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            Console.WriteLine("Program işlem süresi bitti. Dosyanıza bakabilirsiniz... Örnek Dosya Yolu: ");
            Console.WriteLine("Program çalışma klasörü/Debug/Redirect.txt");





        }

    }
}
