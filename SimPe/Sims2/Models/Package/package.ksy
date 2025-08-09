meta:
  id: package
  title: Maxis DataBase Packed File
  file-extension:
    - package
  endian: le
  imports:
    - ../PackedFile/Clist/clst
doc: |
  The Database Packed File is a file format used in many games from Maxis,
  most knowingly in The Sims 2-4, SimCity 4 and Spore.
seq:
  - id: header
    type: header
instances:
  file_index:
    pos: header.index.offset
    type: file_index_item
    repeat: expr
    repeat-expr: header.index.count
  hole_index:
    pos: header.hole.offset
    type: hole_index_item
    repeat: expr
    repeat-expr: header.hole.count
types:
  header:
    seq:
      - id: magic
        contents: "DBPF"
      - id: version_major
        type: u4
      - id: version_minor
        type: u4
      - id: reserved_00
        size: 12
      - id: created
        type: u4
      - id: modified
        type: u4
      - id: index
        type: header_index
      - id: hole
        type: header_hole
      - id: index_type
        type: u4
        if: version_minor >= 1
      - id: ep_icon
        type: s2
      - id: show_icon
        type: s2
      - id: reserved_02
        size: 28
  header_index:
    seq:
      - id: type
        type: s4
      - id: count
        type: s4
      - id: offset
        type: u4
      - id: size
        type: u4
  header_hole:
    seq:
      - id: count
        type: s4
      - id: offset
        type: u4
      - id: size
        type: u4
  file_index_item:
    seq:
      - id: type
        type: u4
        enum: file_type
      - id: group
        type: u4
      - id: instance
        type: u4
      - id: instance_high
        type: u4
        if: _root.header.index_type == 2
      - id: offset
        type: u4
      - id: size
        type: s4
    instances:
      content:
        io: _root._io
        pos: offset
        size: size
        type:
          switch-on: type
          cases:
            "file_type::clst": clst
  hole_index_item:
    seq:
      - id: offset
        type: u4
      - id: size
        type: s4
    instances:
      content:
        io: _root._io
        pos: offset
        size: size
enums:
  file_type:
    0xE86B1EEF: clst
    0xB21BE28B: wthr
