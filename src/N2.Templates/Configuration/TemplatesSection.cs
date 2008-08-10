﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.UI;
using System.Web.Configuration;

namespace N2.Templates.Configuration
{
    public class TemplatesSection : ConfigurationSection
    {
        /// <summary>The database flavour decides which propertes the nhibernate configuration will receive.</summary>
        [ConfigurationProperty("mailConfiguration", DefaultValue = MailConfigSource.ContentRootOrConfiguration)]
        public MailConfigSource MailConfiguration
        {
            get { return (MailConfigSource)base["mailConfiguration"]; }
            set { base["mailConfiguration"] = value; }
        }

        /// <summary>The database flavour decides which propertes the nhibernate configuration will receive.</summary>
        [ConfigurationProperty("masterPageFile", DefaultValue = "~/Layouts/Top+SubMenu.Master")]
        public string MasterPageFile
        {
            get { return (string)base["masterPageFile"]; }
            set { base["masterPageFile"] = value; }
        }

        /// <summary>Configuration related to the wiki module.</summary>
        [ConfigurationProperty("wiki")]
        public WikiElement Wiki
        {
            get { return (WikiElement)base["wiki"]; }
            set { base["wiki"] = value; }
        }

    }
}