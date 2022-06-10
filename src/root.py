# -*- coding: iso-8859-1 -*-

from tkinter import *
from tkinter import ttk
from turtle import end_fill

import src.utils as u

import src.PrgConfig as pc


class Root(Tk):
  ''' ertellt das mainwindow '''
  def __init__(self):
    super(Root, self).__init__()
    pdMain = pc.data["mainwindow"]

    a=0

    ass = u.ck(pdMain,("text", "height", "icon"))

    if u.ck(pdMain,("text")):
      self.title(pdMain["text"])                          # title("Tkinter first Window")

    if u.ck(pdMain,("width", "height")):    
      self.minsize(pdMain["width"], pdMain["height"])     # minsize(640, 400)
    
    if u.ck(pdMain,("icon")): 
      self.wm_iconbitmap(pdMain["icon"])

#    self.labelFrame = ttk.LabelFrame(self, text="My Labelframe")
#    self.labelFrame.grid(column=0, row=7, padx=20, pady=40)

    self.createMenus()
    self.autoste()
#    self.flabels()

  def createMenus(self):
    menubar = Menu(self)
    self.config(menu=menubar)

    file_menu = Menu(menubar, tearoff=0)
    menubar.add_cascade(label="File", menu=file_menu)
    file_menu.add_command(label="New")
    file_menu.add_command(label="Exit")
    file_menu.add_separator()
    file_menu.add_command(label="Open")



  def autoste(self):
    ''' erstellen des Screens '''
    scScreen = pc.data["scr1"]["screen"]

    for xx in scScreen:
      name = xx                 # adr1
      atz = scScreen[name]      # {"type": "label", "pos": [0,0], "text":"Name"}

      if atz["type"] == "label":
        self.label_a1 = ttk.Label(self, text=atz["text"])
        self.label_a1.grid(column=atz["pos"][0],row=atz["pos"][1], sticky=E, padx=5, pady=5)
        atz["wt"] = self.label_a1

      if atz["type"] == "entry":
        self.entry_a1 = ttk.Entry(self)
        self.entry_a1.grid(column=atz["pos"][0],row=atz["pos"][1],sticky=W)
        atz["wt"] = self.entry_a1

      if atz["type"] == "button":
        self.button_a1 = ttk.Button(self, text=atz["text"], command=lambda: self.addlabels("erg1", "entry3", "entry2"))
        self.button_a1.grid(column=atz["pos"][0],row=atz["pos"][1])
        #atz["wt"] = getattr(self.button_a1)
      
      a = 0

    ast = scScreen["adr1"]["type"]


    if ast == ttk.Label:
      pass
    

  def addlabels(self, *values):
    ''' Das ist eine Standardfunktion'''
    
    aaa = values

    spc = pc.data["scr1"]["screen"]
    sa = spc["erg1"]["wt"]
    sb1 = spc["entr1"]["wt"]
    sb2 = spc["entr2"]["wt"]
    sb3 = spc["entr3"]["wt"]

    sa.configure(text="Ergebnis: {anrede} {vname} {nname}".format(anrede = sb1.get(), vname=sb3.get(), nname=sb2.get() ))

    a = 0

#  def flabels(self):
#    ttk.Label(self.labelFrame, text="Label One").grid(column=0, row=0, sticky=W)
#    ttk.Label(self.labelFrame, text="Label Two").grid(column=0, row=1, sticky=W)
#    ttk.Label(self.labelFrame, text="Label Three").grid(column=0, row=2, sticky=W)

