meta:
  id: bnfo
  endian: le
seq:
  - id: version
    type: u4
  - id: current_rank
    type: u4
  - id: highest_rank
    type: u4
  - id: unknown_00
    type: u4
  - id: unknown_01
    type: f4
  - id: unknown_02
    type: u4
  - id: customer_count
    type: u4
  - id: customers
    type: bnfo_customer
    repeat: expr
    repeat-expr: customer_count
  - id: employee_count
    type: u4
  - id: employees
    type: bnfo_employee
    repeat: expr
    repeat-expr: employee_count
  - id: history_count
    type: u4
  - id: history
    type: bnfo_history
    repeat: expr
    repeat-expr: history_count
  - id: unknown_03
    type: u4
types:
  bnfo_employee:
    seq:
      - id: instance
        type: u2
      - id: pay_rate
        type: u4
      - id: fair_pay
        type: u4
  bnfo_customer:
    seq:
      - id: instance
        type: u2
      - id: loyalty
        type: s4
      - id: data_count
        type: u4
      - id: data
        type: u4
        repeat: expr
        repeat-expr: data_count
      - id: data2_count
        type: u4
      - id: data2
        type: u4
        repeat: expr
        repeat-expr: data2_count
      - id: unknown_00
        type: u4
      - id: unknown_01
        type: u4
      - id: stars
        type: s4
  bnfo_history:
    seq:
      - id: unknown_00
        type: u4
      - id: unknown_01
        type: u2
      - id: unknown_02
        type: s4
      - id: unknown_03
        type: u4
      - id: unknown_04
        type: u1
      - id: unknown_05
        type: s4
      - id: unknown_06
        type: u4
      - id: unknown_07
        type: u4
      - id: unknown_08
        type: u4
      - id: unknown_09
        type: s4
      - id: unknown_10
        type: u4
      - id: unknown_11
        type: u4
      - id: unknown_12
        type: s4
      - id: unknown_13
        type: u4
      - id: unknown_14
        type: u1
      - id: unknown_15
        type: u4
      - id: unknown_16
        type: s4
      - id: unknown_17
        type: s4
      - id: unknown_18
        type: s4
      - id: unknown_19
        type: s4
