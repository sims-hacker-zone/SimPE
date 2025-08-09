meta:
  id: ngbh
  file-extension: ngbh
  endian: le
seq:
  - id: fourcc
    contents: HBGN
  - id: version
    type: u4
  - size: 4
  - id: height
    type: u4
  - id: width
    type: u4
  - id: terrain_type_len
    type: u4
  - id: terrain_type
    type: str
    encoding: ascii
    size: terrain_type_len
  - size: 0x14
  - id: universal_tokens
    type: ngbhslot1
    repeat: expr
    repeat-expr: 2
  - id: lots_count
    type: u4
  - id: lots
    type: ngbhslot2
    repeat: expr
    repeat-expr: lots_count
  - id: families_count
    type: u4
  - id: families
    type: ngbhslot2
    repeat: expr
    repeat-expr: families_count
  - id: sims_count
    type: u4
  - id: sims
    type: ngbhslot2
    repeat: expr
    repeat-expr: sims_count
types:
  ngbhslot1:
    seq:
      - id: version
        type: u4
        if: _parent.version >= 0xBE
      - id: special_token_count
        type: u4
      - id: special_tokens
        type: ngbhitem
        repeat: expr
        repeat-expr: special_token_count
      - id: token_count
        type: u4
      - id: tokens
        type: ngbhitem
        repeat: expr
        repeat-expr: token_count
  ngbhslot2:
    seq:
      - id: instance_id
        type: u4
      - id: version
        type: u4
        if: _parent.version >= 0xBE
      - id: special_token_count
        type: u4
      - id: special_tokens
        type: ngbhitem
        repeat: expr
        repeat-expr: special_token_count
      - id: token_count
        type: u4
      - id: tokens
        type: ngbhitem
        repeat: expr
        repeat-expr: token_count
  ngbhitem:
    seq:
      - id: guid
        type: u4
      - id: flags1
        type: u2
      - id: flags2
        type: u2
        if: _root.version >= 0xC2
      - id: inv_number
        type: u4
        if: _root.version >= 0xBE
      - id: unknown
        type: u2
        if: _root.version >= 0xCB
      - id: datacount
        type: u4
      - id: data
        type: u2
        repeat: expr
        repeat-expr: datacount
