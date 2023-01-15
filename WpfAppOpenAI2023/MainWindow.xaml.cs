using OpenAI;
using OpenAI.Edits;
using OpenAI.Embeddings;
using OpenAI.Images;
using OpenAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppOpenAI2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // F01
        // Get and list all available models


        // F02
        // Select model and send request

        /// <summary>
        ///     Test request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string secretKey = txtSecretKey.Text;
            string question = txtQuestion.Text;

            // Establish connection with Open AI
            OpenAIClient openAIClient = new OpenAIClient(new OpenAIAuthentication(secretKey));

            // Get list of all avaiable chat models
            // There are 66 models right now
            IReadOnlyList<Model> models = await openAIClient.ModelsEndpoint.GetModelsAsync();

            // List all available models

            // We are going to use ChatGPT boot "davinchĪ"
            Model model = await openAIClient.ModelsEndpoint.GetModelDetailsAsync("text-davinci-003");

            // "Completion" sample
            //var result = await openAIClient.CompletionsEndpoint.CreateCompletionAsync("If I want to get something, I am usually ...", temperature: 0.75);
            //Console.WriteLine(result.ToString());

            // "Completion" sample
            CompletionResult result = await openAIClient.CompletionsEndpoint.CreateCompletionAsync(question, max_tokens: 2000, temperature: 0.75);
            txtAnswer.Text += result.ToString() + "\n";

            // "Edits"
            //var request = new EditRequest("What day of the wek is it?", "Fix the spelling mistakes");
            //var result2 = await openAIClient.EditsEndpoint.CreateEditAsync(request);
            //Console.WriteLine(result2.ToString());

            // "Image"
            //var results3 = await openAIClient.ImagesEndPoint.GenerateImageAsync("Abracadabra", 1, ImageSize.Small);
            // results == array of image urls to download
        }
    }
}
