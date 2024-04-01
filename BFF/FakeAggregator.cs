using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Net;

namespace BFF
{
    public class FakeAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var response = responses.Select(x => x.Items.DownstreamResponse()).ToArray();

            // In this example we are concatenating the results,
            // but you could create a more complex construct, up to you.
            var contentList = new List<string>();
            foreach (var respons in response)
            {
                var content = await respons.Content.ReadAsStringAsync();
                contentList.Add(content);

            }

            // The only constraint here: You must return a DownstreamResponse object.
            return new DownstreamResponse(
                new StringContent(JsonConvert.SerializeObject(contentList)),
                HttpStatusCode.NotAcceptable,
                response.SelectMany(x => x.Headers).ToList(),
                "reason");
        }
    }
}
