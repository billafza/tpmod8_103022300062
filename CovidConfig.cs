using System.Text.Json;
using System.IO;

public class CovidConfig
{
    public string satuan_suhu { get; set; } = "celcius";
    public int batas_hari_deman { get; set; } = 14;
    public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
    public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

    private const string configPath = "covid_config.json";

    public static CovidConfig LoadConfig()
    {
        if (!File.Exists(configPath))
            return new CovidConfig();

        string json = File.ReadAllText(configPath);
        CovidConfig? config = JsonSerializer.Deserialize<CovidConfig>(json);
        return config ?? new CovidConfig();
    }

    public void SaveConfig()
    {
        string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(configPath, json);
    }

    public void UbahSatuan()
    {
        satuan_suhu = (satuan_suhu.ToLower() == "celcius") ? "fahrenheit" : "celcius";
        SaveConfig();
    }
}