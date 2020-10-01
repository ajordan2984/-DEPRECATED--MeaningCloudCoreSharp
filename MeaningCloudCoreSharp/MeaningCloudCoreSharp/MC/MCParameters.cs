using System.Collections.Generic;

namespace MeaningCloudCoreSharp.MC
{
    public class MCParameters : Dictionary<string, string>
    {
        public MCParameters() {}

        #region Public Properties
        /// <summary>
        /// The access key is required for making requests to any of MeaningCloud web services.
        /// Required.
        /// </summary>
        public string Key 
        {
            get => TryGetValue("key", out var result) ? result : null;
            set => this["key"] = value;
        }

        /// <summary>
        /// Values:	xml or json
        /// Optional. Default: of=json
        /// </summary>
        public string Of
        {
            get => TryGetValue("of", out var result) ? result : null;
            set => this["of"] = value;
        }

        /// <summary>
        /// Values: UTF-8 encoded text (plain text, HTML or XML).
        /// Optional. Default: txt=""
        /// </summary>
        public string Txt
        {
            get => TryGetValue("txt", out var result) ? result : null;
            set => this["txt"] = value;
        }

        /// <summary>
        /// (2020) URL of the content to analyze. Currently only non-authenticated HTTP and FTP are supported. 
        /// Optional. Default: url=""
        /// </summary>
        public string Url
        {
            get => TryGetValue("url", out var result) ? result : null;
            set => this["url"] = value;
        }

        /// <summary>
        /// Not implemented.
        /// Values: Input file with the content to analyze.
        /// The supported formats for file contents can be found at https://www.meaningcloud.com/developer/documentation/supported-formats
        /// Optional. Default: doc=""
        /// </summary>
        //public string Doc
        //{
        //    get => TryGetValue("doc", out var result) ? result : null;
        //    set => this["doc"] = value;
        //}

        /// <summary>
        /// Values: Number of sentences for the summary.
        /// Required.
        /// </summary>
        public string Sentences
        {
            get => TryGetValue("sentences", out var result) ? result : null;
            set => this["sentences"] = value;
        }
        #endregion
    }
}
