public class Script : ScriptBase
{
    public override async Task<HttpResponseMessage> ExecuteAsync()
    {
        HttpResponseMessage response;

        try
        {
            XmlDocument doc = new XmlDocument();
            var contentAsJson = JObject.Parse(await Context.Request.Content.ReadAsStringAsync().ConfigureAwait(false));
            string xmlStr = (string)contentAsJson["xml"];
            if(!String.IsNullOrEmpty(xmlStr)){
                doc.LoadXml(xmlStr);
                var jsonStr = JsonConvert.SerializeXmlNode(doc);

                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = CreateJsonContent(jsonStr);
                return response;
            }
        } catch (Exception e)
        {
        }

        response = new HttpResponseMessage(HttpStatusCode.BadRequest);
        return response;
    }
}
