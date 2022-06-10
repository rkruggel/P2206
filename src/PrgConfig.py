# -*- coding: iso-8859-1 -*-




scr1screen = {
  "adr1" : {"type":"label", "pos":[0,0], "text":"Anrede"},
  "adr2" : {"type":"label", "pos":[0,1], "text":"Name"},
  "adr3" : {"type":"label", "pos":[0,2], "text":"Vorname"},
  "adr4" : {"type":"label", "pos":[0,3], "text":"Zusatz"},
  "entr1" : {"type":"entry", "pos":[1,0], "text":"", "width":20},
  "entr2" : {"type":"entry", "pos":[1,1], "text":"", "width":20},
  "entr3" : {"type":"entry", "pos":[1,2], "text":"", "width":20},
  "entr4" : {"type":"entry", "pos":[1,3], "text":"", "width":20},
  "butt1" : {"type":"button", "pos":[1,4], "text":"Ok", "command":"addlabels", "ergebnis":"erg1", "param" :["entr1", "entr3", "entr2"]},
  "erg1" : {"type":"label", "pos":[1,5], "text":"hier das ergebnis"},

  "lblfrm1": {"type":"labelframe", "pos": [0,7], "text":"Rolands Labelframe", "inner" : {
    "lbltxt1" : {"type":"label", "pos":[0,0], "text":"lbName1"},
    "lbltxt1" : {"type":"label", "pos":[0,0], "text":"lbName2"}
    }  
  } 
}

scr2screen = {
  "adr1" : {"type":"label", "pos":[0,0], "text":"Test"},
  "adr2" : {"type":"label", "pos":[1,0], "text":"Ausgabe"}
}

scr1menu = {

}


data = {
  "name" : "Testprogramm",
  "mainwindow" : { "width":400, "height":500, "text":"Top neues Window", "icon":"" },
  "scr1" : {
    "name" : "scr1",
    "screen" : scr1screen,
    "menu" : scr1menu,
  },
  "scr2" : {
    "name" : "scr2",
    "screen" : scr2screen,
    "menu" : scr1menu
  }
}


