<%@ Control Language="C#" ClassName="ImageGenInstaller" %>
<%@ Import Namespace="System.Xml" %>

    <asp:Label ID="status" runat="server"></asp:Label>


<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        string extraMsg = "";

        try
        {
            // Open web.config file
            XmlDocument WebConfig = new XmlDocument();
            WebConfig.Load(Server.MapPath("~/web.config"));
            bool changedWebConfig = false;

            if (WebConfig.SelectSingleNode("configuration/configSections/section[@name=\"ImageGenConfiguration\"]") == null)
            {

                // Insert <section name="ImageGenConfiguration" type="ImageGen.ImageGenConfigurationHandler,ImageGen" />
                XmlNodeList ConfigSectionsElement = WebConfig.GetElementsByTagName("configSections");

                XmlElement newSection = WebConfig.CreateElement("section");
                newSection.SetAttribute("name", "ImageGenConfiguration");
                newSection.SetAttribute("type", "ImageGen.ImageGenConfigurationHandler,ImageGen");
                XmlNode item = ConfigSectionsElement.Item(0);
                if (item != null)
                {
                    item.AppendChild(newSection);
                    changedWebConfig = true;
                }
            }

            if (WebConfig.SelectSingleNode("configuration/ImageGenConfiguration") == null)
            {
                // Insert <ImageGenConfiguration configSource="config\ImageGen.config" />
                XmlElement ConfigurationElement = WebConfig.DocumentElement; // gets the <configuration> block
                XmlElement newNode = WebConfig.CreateElement("ImageGenConfiguration");
                newNode.SetAttribute("configSource", @"config\ImageGen.config");
                if (ConfigurationElement != null)
                {
                    ConfigurationElement.AppendChild(newNode);
                    changedWebConfig = true;
                }
            }

            // Save web.config file
            if (changedWebConfig)
                WebConfig.Save(Server.MapPath("~/web.config"));
        }

        catch (Exception)
        {
            extraMsg = "<h3>Oops. Problem updating web.config file</h3>";
            extraMsg += "<p>Please update the web.config file manually according to the instructions in the <em>ImageGen Reference Manual</em> PDF file.</p>";
        }

        status.Text = "<h2>ImageGen Installation</h2>";
        status.Text += "<ul>";
        status.Text += "<li>Installed all files</li>";
        status.Text += "<li>Updated web.config</li>";
        status.Text += "</ul>";

        status.Text += extraMsg;

        status.Text += "<h3>Do More with ImageGen Professional</h3>";
        status.Text += "<p>ImageGen Professional has many benefits for professional sites, such as:</p>";
        status.Text += "<ul>";
        status.Text += "<li>Browser-side caching for maximum performance</li>";
        status.Text += "<li>Overlay images for watermarks, frames, etc.</li>";
        status.Text += "<li>Crop and rotate images</li>";
        status.Text += "<li>Advanced text handling</li>";
        status.Text += "<li>Disallow up-sizing images</li>";
        status.Text += "<li>Change to grayscale or sepia color</li>";
        status.Text += "<li>Powerful class features</li>";
        status.Text += "<li>...and much more!</li>";
        status.Text += "</ul>";
        status.Text += "<p><a href=\"http://www.percipientstudios.com/imagegen/features.aspx\" target=\"_blank\">Find out more!</a></p>";
    }
</script>
