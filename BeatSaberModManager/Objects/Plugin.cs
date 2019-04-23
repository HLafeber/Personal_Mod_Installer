using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatSaberModManager.Objects
{
    public class Plugin
    {
        private string _id;
        private bool enabled;
        private string name;
        private string author;
        private string version;
        private string description;
        private string category;
        private bool required;
        private List<string> dependenciesList;

        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public bool Enabled
        {
            get { return this.enabled; }
            set { this.enabled = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        public string Version
        {
            get { return this.version; }
            set { this.version = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public string Category
        {
            get { return this.category; }
            set { this.category = value; }
        }

        public bool Required
        {
            get { return this.required; }
            set { this.required = value; }
        }

        public List<string> DependenciesList
        {
            get { return dependenciesList; }
            set { this.dependenciesList = value; }
        }


    }
}
