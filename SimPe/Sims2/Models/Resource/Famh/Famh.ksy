meta:
  id: famh
  file-extension: famh
  endian: le
seq:
  - id: fourcc
    contents: hMAF
  - id: version
    type: u4
  - size: 5
  - id: section_count
    type: u4
  - id: sections
    type: section
    repeat: expr
    repeat-expr: section_count

types:
  section:
    seq:
      - id: lot_instance
        type: u2
      - id: family_members
        type: u2
      - id: male_adults
        type: u2
      - id: female_adults
        type: u2
      - id: male_children
        type: u2
      - id: female_children
        type: u2
      - id: unknown_00
        type: u2
      - id: unknown_01
        type: u2
      - id: unknown_02
        type: u2
      - id: unknown_03
        type: u2
      - id: unknown_04
        type: u2
      - id: unknown_05
        type: u2
      - id: unknown_06
        type: u2
      - id: unknown_07
        type: u2
      - id: unknown_08
        type: u2
      - id: unknown_09
        type: u2
      - id: unknown_10
        type: u2
      - id: unknown_11
        type: u2
      - id: unknown_12
        type: u2
      - id: unknown_13
        type: u2
      - id: unknown_14
        type: u2
      - id: unknown_15
        type: u2
      - id: unknown_16
        type: u2
      - id: unknown_17
        type: u2
      - id: unknown_18
        type: u2
      - id: unknown_19
        type: u2
      - id: unknown_20
        type: u2
      - id: unknown_21
        type: s4
      - id: unknown_22
        type: s4
      - id: unknown_23
        type: u2
      - id: unknown_24
        type: u2
      - id: money
        type: u4
      - id: family_friends
        type: u2
      - id: unknown_25
        type: s2
      - id: unknown_26
        type: s2
      - id: unknown_27
        type: b1
      - id: unknown_28
        type: s2
      - id: text_count
        type: u4
      - id: text
        type: string
        repeat: expr
        repeat-expr: text_count
  string:
    seq:
      - id: text_len
        type: u4
      - id: text
        type: str
        size: text_len
        encoding: ascii
