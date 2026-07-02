import os

jugadores = [
    ("messi.svg", "LIONEL MESSI", "1", "ARGENTINA", "#75AADB"),
    ("julian_alvarez.svg", "JULIÁN ÁLVAREZ", "2", "ARGENTINA", "#75AADB"),
    ("enzo_fernandez.svg", "ENZO FERNÁNDEZ", "3", "ARGENTINA", "#75AADB"),
    ("de_paul.svg", "RODRIGO DE PAUL", "4", "ARGENTINA", "#75AADB"),
    ("emiliano_martinez.svg", "EMILIANO MARTÍNEZ", "5", "ARGENTINA", "#75AADB"),

    ("vinicius_junior.svg", "VINÍCIUS JÚNIOR", "1", "BRASIL", "#FFDD00"),
    ("raphinha.svg", "RAPHINHA", "2", "BRASIL", "#FFDD00"),
    ("neymar.svg", "NEYMAR JR.", "3", "BRASIL", "#FFDD00"),
    ("marquinhos.svg", "MARQUINHOS", "4", "BRASIL", "#FFDD00"),
    ("alisson_becker.svg", "ALISSON BECKER", "5", "BRASIL", "#FFDD00"),

    ("mbappe.svg", "KYLIAN MBAPPÉ", "1", "FRANCIA", "#0055A4"),
    ("olise.svg", "MICHAEL OLISE", "2", "FRANCIA", "#0055A4"),
    ("tchouameni.svg", "AURÉLIEN TCHOUAMÉNI", "3", "FRANCIA", "#0055A4"),
    ("theo_hernandez.svg", "THEO HERNÁNDEZ", "4", "FRANCIA", "#0055A4"),
    ("maignan.svg", "MIKE MAIGNAN", "5", "FRANCIA", "#0055A4"),

    ("kane.svg", "HARRY KANE", "1", "INGLATERRA", "#C8102E"),
    ("bellingham.svg", "JUDE BELLINGHAM", "2", "INGLATERRA", "#C8102E"),
    ("saka.svg", "BUKAYO SAKA", "3", "INGLATERRA", "#C8102E"),
    ("rashford.svg", "MARCUS RASHFORD", "4", "INGLATERRA", "#C8102E"),
    ("pickford.svg", "JORDAN PICKFORD", "5", "INGLATERRA", "#C8102E"),
]

template = '''<svg width="200" height="280" xmlns="http://www.w3.org/2000/svg">
  <defs>
    <linearGradient id="grad-{id}" x1="0%" y1="0%" x2="0%" y2="100%">
      <stop offset="0%" style="stop-color:{color};stop-opacity:1" />
      <stop offset="100%" style="stop-color:#ffffff;stop-opacity:1" />
    </linearGradient>
  </defs>
  <rect width="200" height="280" fill="url(#grad-{id})" stroke="#333" stroke-width="3" rx="10"/>
  <rect x="10" y="10" width="180" height="200" fill="#ffffff" opacity="0.3" rx="5"/>
  <text x="100" y="110" font-family="Arial, sans-serif" font-size="22" font-weight="bold" fill="#333" text-anchor="middle">{nombre}</text>
  <text x="100" y="160" font-family="Arial, sans-serif" font-size="48" font-weight="bold" fill="#333" text-anchor="middle">{numero}</text>
  <rect x="10" y="220" width="180" height="50" fill="#ffffff" opacity="0.8" rx="5"/>
  <text x="100" y="245" font-family="Arial, sans-serif" font-size="14" font-weight="bold" fill="#333" text-anchor="middle">{pais}</text>
  <text x="100" y="262" font-family="Arial, sans-serif" font-size="12" fill="#666" text-anchor="middle">Mundial 2026</text>
</svg>'''

base_path = "wwwroot/images/jugadores"

for archivo, nombre, numero, pais, color in jugadores:
    svg_content = template.format(
        id=archivo.replace('.svg', ''),
        nombre=nombre,
        numero=numero,
        pais=pais,
        color=color
    )
    
    file_path = os.path.join(base_path, archivo)
    with open(file_path, 'w', encoding='utf-8') as f:
        f.write(svg_content)
    
    print(f"✓ {archivo}")

print("\n✅ Todas las figuritas generadas exitosamente!")
