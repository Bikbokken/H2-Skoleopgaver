using System.Net;

public class Program
{
    static async Task Main(string[] args)
    {
        Request request = new FileRequest();

        Console.WriteLine("Skriv path:");
        string link = Console.ReadLine();
        await request.MakeRequest(link);
    }

}


interface Request
{
    Task MakeRequest(string path);
}

public class HTTPRequest : Request
{
    public async Task MakeRequest(string url)
    {
        HttpClient httpClient = new HttpClient();
        using HttpResponseMessage response = await httpClient.GetAsync(new Uri(url));

        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"{jsonResponse}\n");
    }
}

public class FileRequest : Request
{
    public async Task MakeRequest(string path)
    {
        var fileInfo = new FileInfo(path);
        Console.WriteLine(fileInfo.Name + " - " + fileInfo.CreationTimeUtc);
    }
}