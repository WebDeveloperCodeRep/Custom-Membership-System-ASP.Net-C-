<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
         string JQueryVer = "3.4.1";
     ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
   {
      Path = "https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js",
      DebugPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js",
      CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
      CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
      CdnSupportsSecureConnection = true,
      LoadSuccessExpression = "window.jQuery"
   });
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
