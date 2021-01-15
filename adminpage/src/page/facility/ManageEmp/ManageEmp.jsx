import React, { useState } from "react";
import { Row, Col, Button, message } from "antd";
import { PlusOutlined } from "@ant-design/icons";

import Heading from "../../../compoment/Heading/Heading";

import TableCompoment from "./TableCompoment";
import { useEffect } from "react";
import requestApi from "../../../helper/axios/facilityApi/requestApi";
import AddRequest from "../add/AddRequest";

const ManageEmp = () => {
  const [isRerender, setIsRerender] = useState(false);
  const [data, setData] = useState([]);
  const [isAddRequestOpen, setIsAddRequestOpen] = useState(false);

  useEffect(() => {
    const fetchAllEmp = async () => {
      try {
        const response = await requestApi.getAllEmployee();
        console.log(response);
        const dataTable = response.map((item, index) => {
          return {
            ...item,
            number: index + 1,
            key: item.id,
          };
        });
        setData(dataTable);
      } catch (err) {
        message.error(err.response.data, 5);
      }
    };
    fetchAllEmp();
  }, [isRerender]);

  const handleOpenRequest = () => {
    setIsAddRequestOpen(true);
  };

  return (
    <>
      <AddRequest
        setIsAddRequestOpen={setIsAddRequestOpen}
        isAddRequestOpen={isAddRequestOpen}
        setIsRerender={setIsRerender}
      />
      <div className="px-1 py-1 table fm-viewall">
        <Row className="mb-1">
          <Heading title="Employee Management" />

          <Col className="ml-auto text-right d-flex align-center">
            <Button
              type="primary"
              icon={<PlusOutlined />}
              className="border"
              onClick={handleOpenRequest}
            >
              Create Employee
            </Button>
          </Col>
        </Row>
        <TableCompoment data={data} setIsRerender={setIsRerender} />
      </div>
    </>
  );
};

export default ManageEmp;
