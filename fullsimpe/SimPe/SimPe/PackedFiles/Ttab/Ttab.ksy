meta:
  id: sims2_ttab
  ks-debug: false
  ks-opaque-types: false
  title: TTAB
  application: The Sims 2
  endian: le
doc: |
  TTABs are Pie Menu functions.
seq:
  - id: file_name
    type: str
    encoding: ascii
    size: 64
  - id: header0
    contents: [0xFF, 0xFF, 0xFF, 0xFF]
  - id: format
    type: u4
  - id: header2
    type: u4
  - id: item_count
    type: u2
  - id: items
    type: ttab_item
    repeat: expr
    repeat-expr: item_count
  - id: footer
    size-eos: true
    consume: true
    eos-error: true
types:
  ttab_item:
    seq:
      - id: action
        type: u2
      - id: guard
        type: u2
      - id: counts
        if: _parent.format < 0x54
        type: s4
        repeat: expr
        repeat-expr: "_parent.format < 0x44 ? 1 : 7"
      - id: flags
        type: u2
      - id: flags2
        type: u2
      - id: strindex
        type: u4
      - id: attenuationcode
        type: u4
      - id: attenuationvalue
        type: f4
      - id: autonomy
        type: u4
      - id: joinindex
        type: u4
      - id: uidisplaytype
        type: u2
        if: _parent.format >= 0x45
      - id: facialanimation
        type: u4
        if: _parent.format >= 0x4A
      - id: memoryitermult
        type: f4
        if: _parent.format >= 0x4C
      - id: objecttype
        type: u4
        if: _parent.format >= 0x4C
      - id: modeltableid
        type: u4
        if: _parent.format >= 0x46
      - id: human_groups
        type: ttab_item_motive_human_table
      - id: animal_groups
        type: ttab_item_motive_animal_table
        if: _parent.format >= 0x55
  ttab_item_motive_human_table:
    seq:
      - id: group_count
        type: s4
        if: _parent._parent.format >= 0x54
      - id: groups
        type: ttab_item_motive_human_group
        repeat: expr
        repeat-expr: "_parent._parent.format < 0x44 ? 1 : (_parent._parent.format < 0x54 ? 7 : group_count)"
  ttab_item_motive_human_group:
    seq:
      - id: item_count
        type: s4
        if: _parent._parent._parent.format >= 0x54
      - id: items
        type: ttab_item_single_motive_item
        repeat: expr
        repeat-expr: "_parent._parent._parent.format >= 0x54 ? item_count : 16"
  ttab_item_single_motive_item:
    seq:
      - id: min
        type: s2
        if: _root.format < 0x52
      - id: type_new
        type: s2
        if: _root.format >= 0x52
      - id: delta
        type: s2
        if: _root.format < 0x52
      - id: min_new
        type: s2
        if: _root.format >= 0x52
      - id: type
        type: s2
        if: _root.format < 0x52
      - id: delta_new
        type: s2
        if: _root.format >= 0x52
  ttab_item_motive_animal_table:
    seq:
      - id: group_count
        type: s4
      - id: groups
        type: ttab_item_motive_animal_group
        repeat: expr
        repeat-expr: group_count
  ttab_item_motive_animal_group:
    seq:
      - id: item_count
        type: s4
      - id: items
        type: ttab_item_animal_motive_item
        repeat: expr
        repeat-expr: item_count
  ttab_item_animal_motive_item:
    seq:
      - id: item_count
        type: s4
      - id: items
        type: ttab_item_single_motive_item
        repeat: expr
        repeat-expr: item_count
