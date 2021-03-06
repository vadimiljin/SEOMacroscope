---
layout: post
title: "New v1.7.6 release of SEO Macroscope: Entitled"
date: "2019-01-27 00:00:00 -00:00"
published: true
description: "This release of SEO Macroscope enhances the keyword meta tag analysis for some legacy processing."
excerpt: "This release of SEO Macroscope enhances the keyword meta tag analysis for some legacy processing, and fixes some bugs."
---

This release of SEO Macroscope enhances the keyword meta tag analysis for some legacy processing, and fixes some bugs.
{: .lead }

Source code and an installer can be found on GitHub at:

* [https://github.com/nazuke/SEOMacroscope/releases/tag/v1.7.6.0](https://github.com/nazuke/SEOMacroscope/releases/tag/v1.7.6.0)

Please check the [downloads page]({{ "/downloads/" | relative_url }}) for more recent versions.

## New features in this release include:

* Titles and descriptions are now included in the keywords meta tag analysis. Additionally, some malformed keywords meta tags will be reported as such.
* Some refactoring has been done behind the scenes to try and make the crawled document collection a little more efficient.
* New **Recent URLs** sub-menu under in the **File** menu.
* New **Status Code** columns in the **Links** and and **Hyperlinks** overview lists.
* **Anchor Text** columns added to broken links reports.
* Experimental **Save Session** feature, to save and reload the current crawled session.

## Bug fixes

* Fixed error handling in AnalyzeKeywordPresence.
* Added preferences option to re-fetch linked documents from external sites that initially return a 404 on a HEAD request. This helps to verify links to external sites that have mis-configured webservers, at the expense of network bandwidth.

Please report issues at [https://github.com/nazuke/SEOMacroscope/issues](https://github.com/nazuke/SEOMacroscope/issues).

![SEO Macroscope Application Window]({{ "/media/screenshots/seo-macroscope-main-window-v1.7.5.png" | relative_url }}){: .img-responsive .box-shadow }
{: .screenshot }
