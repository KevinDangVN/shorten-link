import React, { useCallback, useState, useMemo } from "react";
import { Button, Table, Space, Tooltip, Popconfirm, message } from "antd";
import { DeleteOutlined, EditOutlined } from "@ant-design/icons";

import requestApi from "../../../helper/axios/facilityApi/requestApi";
import EditModal from "./EditModal";

const TableCompoment = (props) => {
  const { data, setIsRerender } = props;
  const { Column } = Table;
  const [showEditModal, setShowEditModal] = useState(false);
  const [recordItem, setRecordItem] = useState(null);

  const PAGE_SIZE = 5;

  const handleDeleteRequest = useCallback(
    async (record) => {
      try {
        await requestApi.deleteEmp(record.id);
        message.success("The information was deleted successfully.");
        setIsRerender((pre) => !pre);
      } catch (error) {
        message.error(error.response.data, 5);
      }
    },
    [setIsRerender]
  );

  const handleModal = useCallback((record) => {
    setRecordItem(record);
    setShowEditModal(true);
  }, []);

  return useMemo(
    () => (
      <>
        {recordItem && showEditModal && (
          <EditModal
            showEditModal={showEditModal}
            setShowEditModal={setShowEditModal}
            record={recordItem}
            setIsRerender={setIsRerender}
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
            title="Employee's Name"
            dataIndex="fullName"
            key="fullName"
            width="25%"
          />
          <Column
            title="UserName"
            dataIndex="fullName"
            key="fullName"
            width="25%"
          />
          <Column
            title="Role"
            dataIndex="roleName"
            key="roleName"
            width="25%"
          />

          <Column
            title="Action"
            width="15%"
            render={(record) => (
              <Space size="middle">
                <Tooltip title="View/Edit">
                  <Button
                    type="text"
                    icon={<EditOutlined className="ant-icon icon-primary" />}
                    onClick={() => handleModal(record)}
                  />
                </Tooltip>
                <Popconfirm
                  placement="topLeft"
                  title="Are you sure?"
                  onConfirm={() => handleDeleteRequest(record)}
                >
                  <Button
                    type="text"
                    icon={<DeleteOutlined className="ant-icon icon-danger" />}
                  />
                </Popconfirm>
              </Space>
            )}
          />
        </Table>
      </>
    ),
    [
      data,
      handleDeleteRequest,
      handleModal,
      showEditModal,
      recordItem,
      setIsRerender,
    ]
  );
};

export default TableCompoment;
