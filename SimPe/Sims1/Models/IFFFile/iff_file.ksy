meta:
  id: sims_iff
  title: Maxis IFF Format
  application: The Sims
  file-extension:
    - iff
    - flr
    - wll
    - spf
    - stx
  license: CC0-1.0
  imports:
    - /image/bmp
  encoding: ascii
  endian: be
doc: |
  The Interchange File Format was developed by EA in 1985.
  This version is used in The Sims 1 and The Sims Online
  for a large part of the game logic, including all objects.
  
  It is a container format including various types of resources needed for
  objects.
seq:
  - id: magic1
    contents: 'IFF FILE '
  - id: file_version
    type: str
    size: 3
  - id: magic2_0
    contents: ":TYPE FOLLOWED BY SIZE\0 JAMIE DOORNBOS & MAXIS 1996\0"
    if: file_version == '2.0'
  - id: magic2_5
    contents: ":TYPE FOLLOWED BY SIZE\0 JAMIE DOORNBOS & MAXIS 1"
    if: file_version == '2.5'
  - id: pos_rsmp_header
    type: u4
    if: file_version == '2.5'
  - id: chunks
    type: chunk
    repeat: eos
types:
  chunk:
    seq:
      - id: type
        type: u4
        enum: chunk_types
      - id: len_chunk
        type: u4
      - size: len_chunk - 8
        if: type == chunk_types::xxxx
        id: hole_data
      - id: id
        type: u2
        if: type != chunk_types::xxxx
      - type: u2
        if: type != chunk_types::xxxx
      - id: name
        type: str
        size: 64
        if: type != chunk_types::xxxx
      - id: data
        size: len_chunk-76
        if: type != chunk_types::xxxx
        type:
          switch-on: type
          cases:
            'chunk_types::rsmp': rsmp
            'chunk_types::fwav': fwav
            'chunk_types::bmp_': bmp
            'chunk_types::str': str_resource
            'chunk_types::glob': glob
            'chunk_types::bcon': bcon
            'chunk_types::ttas': ttas
            'chunk_types::ctss': ctss
            'chunk_types::ttab': ttab
            'chunk_types::objf': objf
            'chunk_types::palt': palt
            'chunk_types::spr2': spr2
  rsmp:
    seq:
      - id: reserved
        contents: [0, 0, 0, 0, 0, 0, 0, 0]
      - id: magic
        contents: 'pmsr'
      - id: len_rsmp
        type: u4le
        doc: "May be zero, do not trust it!"
      - id: num_rsmp_chunk_type_entries
        type: u4le
      - id: rsmp_chunk_type_entries
        repeat: expr
        repeat-expr: num_rsmp_chunk_type_entries
        type: rsmp_chunk_type
  rsmp_chunk_type:
    seq:
      - id: type
        type: u4le
        enum: chunk_types
      - id: num_rsmp_sections
        type: u4le
      - id: rsmp_sections
        type: rsmp_section
        repeat: expr
        repeat-expr: num_rsmp_sections
  rsmp_section:
    seq:
      - id: pos_section
        type: u4le
      - id: id
        type: u2le
      - type: u2le
      - id: name
        type: strz
        encoding: ascii
      - id: padding
        size: (2 - _io.pos) % 2
  fwav:
    seq:
      - id: sound_id
        type: strz
        encoding: ascii
  str_resource:
    seq:
      - id: reserved1
        type: u1
      - id: lang_strings
        type: lang_str_resource
        if: reserved1 > 0xf0
      - id: pascal_strings
        type: pascal_str_resource
        if: reserved1 < 0xf0
  lang_str_resource:
    seq:
      - type: u1
      - id: num_strings
        type: u2le
      - id: strings
        type: lang_str
        repeat: expr
        repeat-expr: num_strings
  pascal_str_resource:
    seq:
      - id: num_strings
        type: u1
      - id: strings
        type: pascal_str
        repeat: expr
        repeat-expr: num_strings
  lang_str:
    doc: String with language code and description
    seq:
      - id: language
        type: u1
        enum: lang_str_langs
      - id: str
        type: strz
        encoding: ascii
      - id: description
        type: strz
  glob:
    seq:
      - id: filename
        type: pascal_str
  pascal_str:
    doc: Pascal String
    seq:
      - id: length
        type: u1
      - id: str
        type: str
        size: length
        encoding: ascii
  bcon:
    doc: Constants
    seq:
      - id: num_values
        type: u1
      - id: editable
        type: b1
      - id: values
        type: s2le
        repeat: expr
        repeat-expr: num_values
  ttas:
    seq:
      - type: u2
      - id: num_strings
        type: u2le
      - id: strings
        type: lang_str
        repeat: expr
        repeat-expr: num_strings
  ctss:
    seq:
      - type: u2
      - id: num_strings
        type: u2le
      - id: strings
        type: lang_str
        repeat: expr
        repeat-expr: num_strings
  ttab:
    seq:
      - id: num_interactions
        type: u2le
  objf:
    seq:
      - id: reserved
        contents: [0, 0, 0, 0, 0, 0, 0, 0]
      - id: magic
        type: u4le
        enum: chunk_types
      - id: num_functions_pairs
        type: u4le
      - id: function_pairs
        type: objf_function_pair
        repeat: expr
        repeat-expr: num_functions_pairs
  objf_function_pair:
    seq:
      - id: condition_function
        type: u2le
      - id: action_function
        type: u2le
  palt:
    seq:
      - id: version
        type: u4le
      - id: num_entries
        type: u4le
      - id: reserved
        contents: [0, 0, 0, 0, 0, 0, 0, 0]
      - id: palette_entries
        type: rgb
        repeat: expr
        repeat-expr: num_entries
  rgb:
    seq:
      - id: red
        type: u1
      - id: green
        type: u1
      - id: blue
        type: u1
  spr2:
    seq:
      - id: version
        type: u4le
      - id: sprite_chunk
        type: 
          switch-on: version
          cases:
            1000: spr2_1000
            1001: spr2_1001
  spr2_1000:
    seq:
      - id: num_sprites
        type: u4le
      - id: default_palette
        type: u4le
      - id: ofs_sprites
        type: u4le
        repeat: expr
        repeat-expr: num_sprites
    instances:
      sprites:
        type: spr2_sprite_skel(_index)
        repeat: expr
        repeat-expr: num_sprites - 1
  spr2_1001: {}
  spr2_sprite_skel:
    params:
      - id: i
        type: s4
    instances:
      sprite_body:
        type: spr2_sprite
        pos: _parent.ofs_sprites[i]
        size: _parent.ofs_sprites[i+1] - _parent.ofs_sprites[i]
  spr2_sprite:
    seq:
      - id: width
        type: u2le
      - id: height
        type: u2le
      - id: has_color_channel
        type: b1
      - id: has_z_buffer_channel
        type: b1
      - id: has_alpha_channel
        type: b1
      - id: reserved
        type: b29
      - id: palette
        type: u2le
      - id: transparent_color
        type: u2le
      - id: y_location
        type: u2le
      - id: x_location
        type: u2le
      - id: sprite_data
        size-eos: true
enums:
  chunk_types:
    0x72736d70: rsmp
    0x4f424a44: objd
    0x4f424a66: objf
    0x43545353: ctss
    0x53545223: str
    0x54544142: ttab
    0x54544173: ttas
    0x42484156: bhav
    0x424d505f: bmp_
    0x474c4f42: glob
    0x534c4f54: slot
    0x46574156: fwav
    0x42434f4e: bcon
    0x53505232: spr2
    0x50414c54: palt
    0x58585858: xxxx
  lang_str_langs:
    0x01: us_english
    0x02: uk_english
    0x03: french
    0x04: german
    0x05: italian
    0x06: spanish
    0x07: dutch
    0x09: swedish
    0x0e: portuguese
    0x0f: japanese
    0x10: polish
    0x11: traditional_chinese
    0x12: simplified_chinese
    0x13: thai
    0x14: korean
