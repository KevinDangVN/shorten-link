import React, { useEffect } from "react";
import { message, Row } from "antd";

import Heading from "../../../compoment/Heading/Heading";
import manageRequest from "../../../helper/axios/facilityApi/manageApi";
import { useState } from "react";
import TableView from "./TableView";
import showTime from "../../../helper/other/ConvertDate";

const MangeRequest = () => {
  const [isRerender, setIsRerender] = useState(false);
  const [dataTable, setDataTable] = useState([]);

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
    <div className="px-1 py-1 table manage-fm">
      <Row className="mb-1">
        <Heading title="Quản lý link" />
      </Row>
      <TableView
        data={dataTable}
        setDataTable={setDataTable}
        setIsRerender={setIsRerender}
      />
    </div>
  );
};

export default MangeRequest;
