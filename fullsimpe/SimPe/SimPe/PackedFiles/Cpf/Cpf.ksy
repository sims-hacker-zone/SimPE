meta:
  id: cpf
  endian: le
seq:
  - id: signature
    contents: [0xE0, 0x50, 0xE7, 0xCB, 0x02, 0x00]
  - id: item_count
    type: u4
  - id: items
    type: item
    repeat: expr
    repeat-expr: item_count
types:
  item:
    seq:
      - id: type
        type: u4
        enum: data_type
      - id: key_length
        type: u4
      - id: key
        type: str
        encoding: ascii
        size: key_length
      - id: value_length
        type: s4
        if: type == data_type::string
      - id: str_value
        type: str
        encoding: utf8
        size: value_length
        if: type == data_type::string
      - id: bool_value
        type: b1
        if: type == data_type::bool
      - id: uint_value
        type: u4
        if: type == data_type::uint
      - id: float_value
        type: f4
        if: type == data_type::float
      - id: int_value
        type: u4
        if: type == data_type::int
enums:
  data_type:
    0xEB61E4F7: uint
    0x0B8BEA18: string
    0xABC78708: float
    0xCBA908E1: bool
    0x0C264712: int
