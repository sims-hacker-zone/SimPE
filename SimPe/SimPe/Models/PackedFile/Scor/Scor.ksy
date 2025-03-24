meta:
  id: scor
  file-extension: scor
  endian: le
seq:
  - id: version
    type: u4
  - id: item_count
    type: u4
  - id: items
    type: scor_item
    repeat: expr
    repeat-expr: item_count
types:
  scor_item:
    seq:
      - id: type
        type: u4
      - id: typename_len
        type: u4
      - id: typename
        type: str
        size: typename_len
        encoding: ascii
      - id: content
        type:
          switch-on: type
          cases:
            1: scor_business_rewards
            3: scor_learned_behavior
            5: scor_bff_list
            7: witchnames
  scor_business_rewards:
    seq:
      - id: reward_count
        type: u4
      - id: rewards
        type: reward
        repeat: expr
        repeat-expr: reward_count
  reward:
    seq:
      - id: type
        type: u1
      - id: typename_len
        type: u4
      - id: typename
        type: str
        size: typename_len
        encoding: ascii
      - id: value_type
        type: u1
      - id: int_value
        type: u4
        if: value_type == 1 or value_type == 3
      - id: float_value
        type: f4
        if: value_type == 0
  scor_learned_behavior:
    seq:
      - id: behavior_count
        type: u4
      - id: data
        size: 10
        repeat: expr
        repeat-expr: behavior_count
  scor_bff_list:
    seq:
      - id: bff_count
        type: u4
      - id: data
        size: 30
        repeat: expr
        repeat-expr: bff_count
  witchnames:
    seq:
      - id: name_count
        type: u4
      - id: names
        type: witchname
        repeat: expr
        repeat-expr: name_count
  witchname:
    seq:
      - contents: [1]
      - id: id
        type: u4
      - contents: [4]
      - id: name_len
        type: u4
      - id: name
        type: str
        size: name_len
        encoding: utf8
