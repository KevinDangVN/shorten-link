import { message, Table, Tooltip, Button, Popconfirm } from "antd";
import Column from "antd/lib/table/Column";
import React, { useState } from "react";
import { DeleteOutlined, EditOutlined } from "@ant-design/icons";
import manageRequest from "../../../helper/axios/facilityApi/manageApi";
import EditLink from "./EditLink";

const TableView = (props) => {
  const { data, setIsRerender } = props;
  const PAGE_SIZE = 8;

  const [isEditModalOpen, setIsEditModalOpen] = useState(false);
  const [recordItem, setRecordItem] = useState(null);

  const handleDelete = async (record) => {
    try {
      await manageRequest.deleteLink(record.id);
      setIsRerender((pre) => !pre);
    } catch (err) {
      message.error("Something went wrong, please try again!", 5);
    }
  };

  return (
    <>
      {recordItem && isEditModalOpen && (
        <EditLink
          isEditModalOpen={isEditModalOpen}
          setIsEditModalOpen={setIsEditModalOpen}
          setIsRerender={setIsRerender}
          record={recordItem}
        />
      )}
      <Table
        dataSource={data}
        bordered
        pagination={{ pageSize: PAGE_SIZE }}
        scroll={{ x: 600, y: 600 }}
      >
        <Column title="#" dataIndex="number" key="number" width="4%" />
        <Column
          title="Full Link"
          dataIndex="fullLink"
          key="fullLink"
          width="20"
          sorter={(a, b) => {
            if (
              typeof a.fullLink === "string" &&
              typeof b.fullLink === "string"
            ) {
              return a.fullLink.localeCompare(b.fullLink);
            }
          }}
        />
        <Column
          title="Slug"
          dataIndex="shortLink"
          key="shortLink"
          width="20"
          sorter={(a, b) => {
            if (
              typeof a.shortLink === "string" &&
              typeof b.shortLink === "string"
            ) {
              return a.shortLink.localeCompare(b.shortLink);
            }
          }}
        />
        <Column
          title="Total Click"
          dataIndex="count"
          key="count"
          width="20"
          sorter={(a, b) => a < b}
        />
        <Column
          title="Date created"
          dataIndex="date"
          key="date"
          width="20"
          sorter={(a, b) => new Date(a.createdAt) < new Date(b.createdAt)}
        />
        <Column
          title="Thao tác"
          key="fmAction"
          render={(_, record) => {
            return (
              <div className="manage-fm__name">
                <Tooltip title="View/Edit">
                  <Button
                    type="text"
                    icon={<EditOutlined className="ant-icon icon-primary" />}
                    onClick={() => {
                      setRecordItem(record);
                      setIsEditModalOpen(true);
                    }}
                  />
                </Tooltip>
                <Popconfirm
                  placement="topLeft"
                  title="Are you sure to delete this link?"
                  onConfirm={() => handleDelete(record)}
                >
                  <Button
                    type="text"
                    icon={<DeleteOutlined className="ant-icon icon-danger" />}
                  />
                </Popconfirm>
              </div>
            );
          }}
        />
      </Table>
    </>
  );
};

export default TableView;
