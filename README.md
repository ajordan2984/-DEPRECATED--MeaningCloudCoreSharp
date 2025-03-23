[DEPRECATED]

![Project frozen](https://img.shields.io/badge/status-frozen-blue.png) ![Project unmaintained](https://img.shields.io/badge/project-unmaintained-red.svg)

# MeaningCloudCoreSharp
This is a library written in C# for https://www.meaningcloud.com/products/automatic-summarization

## Dependencies
Dependency        | Version
----------------- | -------------
.NET Core         | 3.1
Newtonsoft        | 12.0.3

## Example
This is how you would make your request
```cs
var client = new MCClient(new MCParameters()
            {
                Key = "YOUR API KEY HERE",
                Url = "https://en.wikipedia.org/wiki/Augustus",
                Sentences = "3"
            });

var mc = client.Download();
```

**OR**

```cs
var text = File.ReadAllText("exampleTextFile.txt");

var client = new MCClient(new MCParameters()
            {
                Key = "YOUR API KEY HERE",
                Txt = text
                Sentences = "3"
            });

var mc = client.Download();
```
