#TC.BrowserStack.Screenshots

Automate product of screenshots from BrowserStack. Vary url, orientation, browsers etc. Option to download images locally.

WARNING: Not a free service. You require the Team Plus for Screenshots & Responsive to access the API.

Details of json format required here.

http://www.browserstack.com/screenshots/api#generate-screenshots

##Instructions

```Screenshots browsers```

Will download the `browsers.json` file to your working directory.

```Screenshots jobs JobsDefinition.json```

Will run a set of jobs across multiple pages with the same default settings. Datestamp logfile created in working directory.

```Screenshots images 2014-10-31-22-14.json```

Will download the images (and wait if not processed yet) to a folder of the same name as the log file.
