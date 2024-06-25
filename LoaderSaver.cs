using Newtonsoft.Json;

public class Project
{
    public string Name { get; set; }
    public string GitUrl { get; set; }
    public string SoftwareOpen { get; set; }
    public string Path { get; set; }
    public string Status { get; set; }
}

public class Data
{
    public string Message { get; set; }
    public List<Project> Projects { get; set; }
}

public class JsonFileHandler
{
    private readonly string _filePath;

    public JsonFileHandler(string filePath)
    {
        _filePath = filePath;
    }

    public void SaveData(Data data)
    {
        var jsonData = JsonConvert.SerializeObject(data);
        File.WriteAllText(_filePath, jsonData);
    }

    public Data LoadData()
    {
        if (!File.Exists(_filePath))
        {
            return null;
        }

        var jsonData = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<Data>(jsonData);
    }
    
    public Dictionary<string, object> EditData(Dictionary<string, object> data)
    {
        if (!File.Exists(_filePath))
        {
            return null;
        }

        var jsonData = File.ReadAllText(_filePath);
        var loadedData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);

        // Update the properties in the dictionary
        foreach (var item in data)
        {
            loadedData[item.Key] = item.Value;
        }

        // Serialize the dictionary back into a JSON string and write it to the file
        jsonData = JsonConvert.SerializeObject(loadedData);
        File.WriteAllText(_filePath, jsonData);

        // Return the updated dictionary
        return loadedData;
    }
}