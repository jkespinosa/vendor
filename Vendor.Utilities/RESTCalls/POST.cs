
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor.Utilities.RESTCalls
{
   
    public class POST
    { 
        private readonly IConfiguration Configuration;

        public POST(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /*Se crea metodo post generico para obtener archivo .csv*/
        public static async Task POSTCall(String filePath)
        {
         
            // Verificar si el archivo existe
            if (!File.Exists(filePath))
            {
                Console.WriteLine("El archivo CSV no existe.");
                return;
            }

            /*Configuracion para el certificado local*/
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


            // URL de la API donde se enviará el archivo
            //string apiUrl = "https://webservices.mortgage.vendor.com/api/createLoan";
            string apiUrl = "https://localhost:7214/api/createLoan";


            using (var client = new HttpClient(clientHandler))
            using (var form = new MultipartFormDataContent())
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var content = new StreamContent(fileStream))
            {
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/csv");

                // Agregar el archivo al form-data con el nombre "file"
                form.Add(content, "file", Path.GetFileName(filePath));

                // Enviar la petición POST a la API
                HttpResponseMessage response = await client.PostAsync(apiUrl, form).ConfigureAwait(false);

                // Leer la respuesta de la API
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Respuesta de la API: {result}");
            }
        }

    }
}
