using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using LattanaService.Models;
using Microsoft.Extensions.Configuration;

namespace LattanaService.Services.FileSystem
{
    public class AudioRepository
    {
        private readonly IConfiguration _configuration;

        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        private IList<LocalAudio> _cachedAudios;

        private IEnumerable<LocalAudio> LocalAudios
        {
            get
            {
                if (_cachedAudios != null && _cachedAudios.Count == 0) return _cachedAudios;

                _cachedAudios = GetAudios();
                return _cachedAudios;
            }
        }

        public AudioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IList<LocalAudio> GetAudios()
        {
            var json = File.ReadAllText(_configuration["configurationPath"]);

            return JsonSerializer.Deserialize<LocalAudio[]>(json, JsonOptions);
        }

        public IEnumerable<LocalAudio> GetByKeywords(string[] keywords)
        {
            return LocalAudios
                .Where(la =>
                    la.Keywords.Length >= keywords.Length &&
                    la.Keywords.Count(k => keywords.Any(k.StartsWith)) >= keywords.Length)
                .Take(5)
                .ToList();
        }
    }
}