using System;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = CovidConfig.LoadConfig();

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hari = Convert.ToInt32(Console.ReadLine());

        bool suhuValid = false;

        if (config.satuan_suhu.ToLower() == "celcius")
        {
            suhuValid = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (config.satuan_suhu.ToLower() == "fahrenheit")
        {
            suhuValid = suhu >= 97.7 && suhu <= 99.5;
        }

        bool hariValid = hari < config.batas_hari_deman;

        if (suhuValid && hariValid)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        // Panggil method untuk ubah satuan jika ingin testing
        Console.WriteLine("Ingin mengubah satuan suhu? (y/n)");
        if (Console.ReadLine().ToLower() == "y")
        {
            config.UbahSatuan();
            Console.WriteLine($"Satuan suhu sekarang: {config.satuan_suhu}");
        }
    }
}