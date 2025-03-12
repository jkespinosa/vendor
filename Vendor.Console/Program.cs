using RestSharp;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;

Console.WriteLine("Hello, World!");


Main();


async static Task Main()
{


    try
    {
        string filePath = @"C:\Users\HP2022\Documents\GitHub\InputFile_Sample_v3 01.03.25.csv";

        await Vendor.Utilities.RESTCalls.POST.POSTCall(filePath);

    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error inesperado: {ex.Message}");
    }
}

Console.ReadKey();

