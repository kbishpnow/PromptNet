using System.Text;
using OllamaSharp;

namespace PromptNet.ClassLib
{
    internal class OllamaAccess
    {
        // requires Ollama to be running locally on port 11434
        // Ollama can be installed from https://ollama.com/download
        // Could replace with an IP for remote access (open port 11434 in firewall)
        readonly OllamaApiClient ollama = new("http://localhost:11434");

        public void SelectModel(string name)
        {
            ollama.SelectedModel = name switch
            {
                "llama3.3" => "llama3.3:latest",
                _ => "llama3.3:latest",
            };
        }

        public async Task<IEnumerable<OllamaSharp.Models.Model>> GetModelsAsync()
        {
            var models = await ollama.ListLocalModelsAsync();
            return models;
        }

        public async Task<string> GetResponse(string prompt)
        {
            var responseBuilder = new StringBuilder();

            await foreach (var stream in ollama.GenerateAsync(prompt))
            {
                if (stream?.Response != null)
                {
                    responseBuilder.Append(stream.Response);
                }
            }

            return responseBuilder.ToString(); // Return the complete response as a single string
        }

    }
}
