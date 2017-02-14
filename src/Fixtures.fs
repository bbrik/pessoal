module Pessoal.Fixtures


let simplifyNomeTable = [
    "super zona sul lj \d+", "zona sul"
    "supermercado zona sul", "zona sul"
    "super merc zona sul", "zona sul"
    "restaurante zona sul \d+", "zona sul"
    "uber\*uber", "uber"
    "uber uber br\w*", "uber"
    "\.\*ifood", "ifood"
    "ifood com", "ifood"
    "prezunic \d+", "prezunic"
    "lojas americanas \d+", "lojas americanas"
    "domino s spoleto filia", "dominos"
    "princesa auto s de com", "princesa"
    "merc e granja cento", "quality"
]
