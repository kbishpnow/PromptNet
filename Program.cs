using PromptNet.ClassLib;


OllamaAccess ai = new();

// Get the list of models
var models = await ai.GetModelsAsync();

foreach (var model in models)
{
    Console.WriteLine($"Model: {model.Name}");
}

// Select different models or makefile personas
ai.SelectModel("default");

// Get a response from the model
string response = await ai.GetResponse("What is the capital of France?");

// Output the response
Console.WriteLine($"Response: {response}");