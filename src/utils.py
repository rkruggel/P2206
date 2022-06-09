# -*- coding: iso-8859-1 -*-

def ck(data, value):
  """Testet ob das Attribut 'value' in dem Dictionary 'data' vorhanden ist und ob es Daten enthält.

  Args:
      data (Dict): Das Dictionary das gerüft werden soll
      value (String): Der String der in data gesucht werden soll

  Returns:
      boolean: True wenn das Attribut vorhanden ist
  """
  erg = False
  for ii in value:
    if ii in data:
      erg = True
      if len(ii) == 0: 
        return False
    else: 
        return False
  return erg

