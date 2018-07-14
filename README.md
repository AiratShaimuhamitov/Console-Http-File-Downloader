# Console-Http-File-Downloader
Decision for this https://github.com/Ecwid/new-job/blob/f4c62fb8b5e479b6e9c81c3ea4c57ad338ccbe75/Console-downloader.md. 

Console utility for downloading files via HTTP protocol.

<pre>
Input parameters:
  -n number of simultaneously pumping threads (1,2,3,4 ....)
  -l total download speed limit, for all threads, dimension - byte / second, you can use the suffixes k, m (k = 1024, m = 1024 * 1024)
  -f path to the file with the list of links
  -o name of the folder where the downloaded files will be added
  </pre>
