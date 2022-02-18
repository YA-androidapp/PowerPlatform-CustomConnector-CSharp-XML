public class Script : ScriptBase
{
    public override async Task<HttpResponseMessage> ExecuteAsync()
    {
        
        XmlDocument doc = new XmlDocument();
        var contentAsJson = JObject.Parse(await Context.Request.Content.ReadAsStringAsync().ConfigureAwait(false));
        doc.LoadXml((string)contentAsJson["xml"]);
        var jsonStr = JsonConvert.SerializeXmlNode(doc);

        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = CreateJsonContent(jsonStr);
        return response;
    }
}
