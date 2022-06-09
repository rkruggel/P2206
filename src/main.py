#!/usr/bin/env python3
# -*- coding: iso-8859-1 -*-

import sys
import os
from sys import argv

import src.root as root


progname = None
argv = ["","ProgConfig"]            # Ist nur wärend der entwicklung notwenedig

if len(argv) > 1:
  progname = argv[1]
else:
  print("Usage: main.py Progname")
  sys.exit()

filename = os.path.splitext(progname)[0]
progname = filename + ".py"


a=0




if __name__ == "__main__":
  root = root.Root()
  root.mainloop()
