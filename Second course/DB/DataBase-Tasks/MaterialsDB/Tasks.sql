use materialsdb

-- Task 1
--SQL
SELECT c.oper_num, m.name, c.det_code, c.consumption
FROM MaterialsConsumption c, Materials m 
WHERE c.mat_code = m.mat_code
AND c.oper_num = value  -- ������������ ���������

--RA
[oper_num, name, det_code, consumption]([oper_num = value](MaterialsConsumption))*(Materials)

-- RIK
�����{(c.oper_num, m.name, c.det_code, c.consumption) | c in MaterialsConsumption, m in Materials} 
		c.mat_code = m.mat_code & c.oper_num = value



-- Task 2
SELECT c.det_code, c.oper_num, worker_code, worker_qualif, tariff_code, pf_time, piece_time 
FROM ManufacturingCosts c
WHERE NOT EXISTS (SELECT * FROM Materials m 
				  WHERE m.price > 100 
						AND NOT EXISTS (SELECT * FROM MaterialsConsumption mc
										WHERE mc.consumption > 20 
											  AND mc.det_code = c.det_code
											  AND mc.oper_num = c.oper_num
											  AND mc.mat_code = m.mat_code))

-- �� �������� ������: SELECT 5 FORALL 1 EXISTS 4

-- RA
[det_code, oper_num, worker_code, worker_qualif, tariff_code, pf_time, piece_time]
(([det_code, mat_code, oper_num][consumption > 20](MaterialsConsumption)) / ([mat_code][price > 100](Materials)))*(ManufacturingCosts)

-- RIK
�����{(c.det_code, c.oper_num, c.worker_code, c.worker_qualif, c.tariff_code, c.pf_time, c.piece_time) | c in ManufacturingCosts} 
		FORALL (m in Materials) m.price > 100 ->
		( EXISTS(mc in MaterialsConsumption) mc.det_code = c.det_code & mc.mat_code = m.mat_code & mc.consumption > 20 )