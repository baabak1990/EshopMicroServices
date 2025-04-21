using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StateMachineDemo
{
    public class LibraryService(HttpClient httpClient)
    {
        public async Task<List<LibraryModel>> getlibraries()
        {
            var response = await httpClient.GetAsync("http://somecodes");
            response.EnsureSuccessStatusCode();


            var contentstream = await response.Content.ReadAsStreamAsync();
            var libraries = await JsonSerializer.DeserializeAsync<List<LibraryModel>>(contentstream);
            return libraries ?? throw new InvalidOperationException("libraries not found");
        }
    }
}

//public struct no : IAsyncStateMachine
//{
//    public void MoveNext()
//    {
//        throw new NotImplementedException();
//    }

//    public void SetStateMachine(IAsyncStateMachine stateMachine)
//    {
//        throw new NotImplementedException();
//    }
//}

public class LibraryModel
{
    public required string sample { get; set; }
    public required string sampleSec { get; set; }
    public required string sampleThird { get; set; }

}