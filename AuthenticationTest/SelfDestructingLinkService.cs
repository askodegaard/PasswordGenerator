using System;
using System.Collections.Concurrent;

namespace AuthenticationTest
{

    public class SelfDestructingLinkService
    {
        private ConcurrentDictionary<string, string> _links = new();

        public string CreateLink(string data)
        {
            var token = Guid.NewGuid().ToString();
            _links[token] = data;  // Store the associated data
            return $"/selfdestruct/{token}"; // Generate a unique URL
        }

        public string? GetAndDestroyLink(string token)
        {
            if (_links.TryRemove(token, out var data))
            {
                return data; // Return the data and remove the link
            }
            return null; // If not found, return null
        }
    }

}
