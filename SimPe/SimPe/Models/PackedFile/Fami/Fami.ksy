meta:
  id: fami
  file-extension: fami
  endian: le
seq:
  - id: signature
    contents: "IMAF"
  - id: version
    type: u4
  - id: unknown_00
    type: u4
  - id: lot_instance
    type: u4
  - id: current_lot_instance
    type: u4
    if: version >= 81
  - id: vacation_lot_instance
    type: u4
    if: version >= 85
  - id: family_name_instance
    type: u4
    if: version < 86
  - id: money
    type: u4
    if: version < 86
  - id: family_friends
    type: u4
  - id: flags
    type: u4
  - id: member_count
    type: u4
  - id: members
    type: u4
    repeat: expr
    repeat-expr: member_count
  - id: album_guid
    type: u4
  - id: subhood_number
    type: u4
    if: version >= 79
  - id: business_money
    type: u4
    if: version >= 81 and version <= 86
