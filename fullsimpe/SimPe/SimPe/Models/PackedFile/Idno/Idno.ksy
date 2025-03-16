meta:
  id: idno
  endian: le
seq:
  - id: version
    type: u4
  - id: name_length
    type: u4
  - id: name
    type: str
    encoding: ascii
    size: name_length
  - id: uid
    type: u4
  - id: type
    type: u4
    if: version >= 5
  - id: subtype_length
    type: u4
    if: version >= 5
  - id: subtype_name
    type: str
    size: subtype_length
    if: version >= 5
    encoding: ascii
  - id: reserved_00
    type: u4
    if: version >= 0xA
  - id: required_ep
    type: u4
    if: version >= 0xA
  - id: affiliated_ep
    type: u4
    if: version >= 0xA
  - id: id_flags
    type: u4
    if: version >= 0xA
  - id: first_season
    type: u1
    if: version >= 0xA
  - id: second_season
    type: u1
    if: version >= 0xA
  - id: third_season
    type: u1
    if: version >= 0xA
  - id: forth_season
    type: u1
    if: version >= 0xA
