import React, { useEffect } from "react";
import { Button, Col, message, Row } from "antd";

import Heading from "../../../compoment/Heading/Heading";
import manageRequest from "../../../helper/axios/facilityApi/manageApi";
import { useState } from "react";
import TableView from "./TableView";
import showTime from "../../../helper/other/ConvertDate";
import { PlusOutlined } from "@ant-design/icons";
import CreateLink from "./CreateLink";

const MangeRequest = () => {
  const [isRerender, setIsRerender] = useState(false);
  const [dataTable, setDataTable] = useState([]);
  const [isCreateModalOpen, setIsCreateModalOpen] = useState(false);

  useEffect(() => {
    const getAllRequest = async () => {
      try {
        const response = await manageRequest.getAllLink();
        console.log(response);
        const convertedData = response.map((item, index) => ({
          ...item,
          key: item.id,
          number: ++index,
          fullLink: item.fullLink,
          shortlink: item.shortlink,
          count: item.count,
          date: showTime(item.createdAt),
        }));
        setDataTable(convertedData);
      } catch (error) {
        message.error(error.message, 5);
      }
    };
    getAllRequest();
  }, [isRerender]);

  return (
    <>
      <CreateLink
        isCreateModalOpen={isCreateModalOpen}
        setIsCreateModalOpen={setIsCreateModalOpen}
        setIsRerender={setIsRerender}
      />
      <div className="px-1 py-1 table manage-fm">
        <Row className="mb-1">
          <Heading title="Slug Management" />
          <Col className="ml-auto text-right d-flex align-center">
            <Button
              type="primary"
              icon={<PlusOutlined />}
              className="border"
              onClick={() => setIsCreateModalOpen(true)}
            >
              Create link
            </Button>
          </Col>
        </Row>

        <TableView
          data={dataTable}
          setDataTable={setDataTable}
          setIsRerender={setIsRerender}
        />
      </div>
    </>
  );
};

export default MangeRequest;
