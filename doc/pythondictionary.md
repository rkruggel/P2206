# P2206

## Der configfile



<pre>
scr1screen = {
  "adr1" : {"type":"label", "pos":[0,0], 
            "text":"Name"},
  "entr1" : {"type":"entry", "pos":[1,0], 
             "text":"", "width":20},
  "butt1" : {"type":"button", "pos":[1,4], 
             "text":"Ok", "command":["print",""]},

  "lblfrm1": {"type":"labelframe", "pos": [0,7], "text":"Rolands Labelframe", "inner" : {
    "lbltxt1" : {"type":"label", "pos":[0,0], "text":"lbName1"},
    "lbltxt1" : {"type":"label", "pos":[0,0], "text":"lbName2"}
    }
  }
}
</pre>

Hier wird ein screen definiert.



<pre>
scr2screen = {
  "adr1" : {"type":"label", "pos":[0,0], "text":"Test"},
  "adr2" : {"type":"label", "pos":[1,0], "text":"Ausgabe"}
}
</pre>

<pre>
scr1menu = {
}
</pre>

<pre>
data = {
  "mainwindow" : { 
    "name" : "Testprogramm",
    "width":400, "height":500, 
    "text":"Top neues Window",
    "icon":"" },
  "scr1" : {
    "name" : "scr1",
    "screen" : scr1screen,
    "menu" : scr1menu },
  "scr2" : {
    "name" : "scr2",
    "screen" : scr2screen,
    "menu" : scr1menu
  }
}
</pre>

In *data* wird alles zusammengesetzt.

Aufrufe der einzelnen Teile von *data*
- *mainwindow* wird bein Programmstart aufgerufen.
- *scr1 .. scrx* wird aus dem Menü aus aufgerufen. Es wird automatisch ein Menüeintrag erstellt.

Die Datenbank bzw die Tabellen werden automatisch erstellt. Die Datenbank heißt wie *name* des *mainwindow*. Die Tabellen heißen wie *name* der einzelnen *scrx*



