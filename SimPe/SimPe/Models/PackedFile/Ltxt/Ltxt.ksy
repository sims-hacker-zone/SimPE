meta:
  id: ltxt
  file-extension: ltxt
  endian: le
seq:
  - id: version
    type: u2
  - id: subversion
    type: u2
  - id: width
    type: s4
  - id: height
    type: s4
  - id: type
    type: u1
  - id: lot_roads
    type: u1
  - id: lot_rotation
    type: u1
  - id: lot_flags
    type: u4
  - id: name_length
    type: u4
  - id: name
    type: str
    encoding: utf8
    size: name_length
  - id: desc_length
    type: u4
  - id: description
    type: str
    encoding: utf8
    size: desc_length
  - id: elevation_offsets_count
    type: s4
  - id: elevation_offsets
    type: f4
    repeat: expr
    repeat-expr: elevation_offsets_count
  - id: unknown_00
    type: f4
    if: subversion >= 7
  - id: lot_hobby_flags
    type: u4
    if: subversion >= 8
  - id: num_apartments
    type: u1
    if: version >= 0x12 or subversion >= 0xB
  - id: apartment_rent_price_high
    type: u4
    if: version >= 0x12 or subversion >= 0xB
  - id: apartment_rent_price_low
    type: u4
    if: version >= 0x12 or subversion >= 0xB
  - id: lot_class_value
    type: u4
    if: version >= 0x12 or subversion >= 0xB
  - id: use_set_lot_class_value
    type: b1
    if: version >= 0x12 or subversion >= 0xB
  - id: y
    type: s4
  - id: x
    type: s4
  - id: lot_elevation
    type: f4
  - id: lot_instance
    type: u4
  - id: orientation
    type: u1
  - id: texture_len
    type: u4
  - id: texture
    type: str
    size: texture_len
    encoding: utf8
  - id: unknown_01
    type: u1
  - id: business_owner_instance
    type: u4
    if: version >= 0xE
  - id: apartment_base
    type: u4
    if: version >= 0x12 or subversion >= 0xB
  - id: unknown_02
    size: 9
    if: version >= 0x12 or subversion >= 0xB
  - id: sublot_count
    type: u4
    if: version >= 0x12 or subversion >= 0xB
  - id: sublots
    type: sublot
    repeat: expr
    repeat-expr: sublot_count
  - id: unknown_03_count
    type: u4
    if: version >= 0x12 or subversion >= 0xB
  - id: unknown_03
    type: u4
    repeat: expr
    repeat-expr: unknown_03_count
types:
  sublot:
    seq:
      - id: sublot_instance
        type: u4
      - id: family
        type: u4
      - id: unknown_00
        type: u4
      - id: roommate_instance
        type: u4
