using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AllegroGitHub.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectInterfaces;

namespace AllegroGitHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        // Get: api/GitHub/user
        [HttpGet("{user}")]
        public async Task<string> Get(string user)
        {
            List<GitHubData> ListFromGitHub = await GetDataFromGitHub(user);
            List<GitHubStats> FinalResult = new List<GitHubStats>();
            foreach (var item in ListFromGitHub)
            {                
                FinalResult.Add(new GitHubStats
                {
                    avgWatchers = item.watchers_count,
                    owner = item.owner.login,
                    avgStargazers = item.stargazers_count,
                    avgForks = item.forks_count,
                    avgSize = item.size,
                    name = item.name,
                    
                    letters_used = new Letters
                    {
                        A = item.name.ToCharArray().Count(c => c == 'A' || c == 'a'),
                        B = item.name.ToCharArray().Count(c => c == 'B' || c == 'b'),
                        C = item.name.ToCharArray().Count(c => c == 'C' || c == 'c'),
                        D = item.name.ToCharArray().Count(c => c == 'D' || c == 'd'),
                        E = item.name.ToCharArray().Count(c => c == 'E' || c == 'e'),
                        F = item.name.ToCharArray().Count(c => c == 'F' || c == 'f'),
                        G = item.name.ToCharArray().Count(c => c == 'G' || c == 'g'),
                        H = item.name.ToCharArray().Count(c => c == 'H' || c == 'h'),
                        I = item.name.ToCharArray().Count(c => c == 'I' || c == 'i'),
                        J = item.name.ToCharArray().Count(c => c == 'J' || c == 'j'),
                        K = item.name.ToCharArray().Count(c => c == 'K' || c == 'k'),
                        L = item.name.ToCharArray().Count(c => c == 'L' || c == 'l'),
                        M = item.name.ToCharArray().Count(c => c == 'M' || c == 'm'),
                        N = item.name.ToCharArray().Count(c => c == 'N' || c == 'n'),
                        O = item.name.ToCharArray().Count(c => c == 'O' || c == 'o'),
                        P = item.name.ToCharArray().Count(c => c == 'P' || c == 'p'),
                        R = item.name.ToCharArray().Count(c => c == 'Q' || c == 'q'),
                        S = item.name.ToCharArray().Count(c => c == 'R' || c == 'r'),
                        T = item.name.ToCharArray().Count(c => c == 'T' || c == 't'),
                        U = item.name.ToCharArray().Count(c => c == 'U' || c == 'u'),
                        V = item.name.ToCharArray().Count(c => c == 'V' || c == 'v'),
                        W = item.name.ToCharArray().Count(c => c == 'W' || c == 'w'),
                        X = item.name.ToCharArray().Count(c => c == 'X' || c == 'x'),
                        Y = item.name.ToCharArray().Count(c => c == 'Y' || c == 'y'),
                        Z = item.name.ToCharArray().Count(c => c == 'Z' || c == 'z'),
                    }
                }
            );
            }
            var json = JsonConvert.SerializeObject(FinalResult, Formatting.Indented);
            return json;
        }
        public async Task<List<GitHubData>> GetDataFromGitHub(string user)
        {
            string url = $"https://api.github.com/users/{user}/repos";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.TryParseAdd(user);
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<List<GitHubData>>(jsonString);
                    return model;
                }
            }
        }
    }
}