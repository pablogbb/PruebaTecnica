﻿using PruebaTecnica.Web;
using Xunit;

namespace PruebaTecnica.FunctionalTests.ControllerApis;
[Collection("Sequential")]
public class MetaControllerInfo : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public MetaControllerInfo(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsVersionAndLastUpdateDate()
  {
    var response = await _client.GetAsync("/info");
    response.EnsureSuccessStatusCode();
    var stringResponse = await response.Content.ReadAsStringAsync();

    Assert.Contains("Version", stringResponse);
    Assert.Contains("Last Updated", stringResponse);
  }
}
