import { useParams } from 'react-router-dom'
import { useFetchHouseDetail, useUpdateHouse } from '../hooks/HouseHooks'
import Form from './Form'
import ApiStatus from './ApiStatus'
import ValidationSummary from './ValidationSummary'

type Props = {}

const HouseEdit = (props: Props) => {
  const { id } = useParams()
  if (!id) throw Error('House Id not found!')

  const houseId = parseInt(id)
  const { data, status, isSuccess } = useFetchHouseDetail(houseId)
  const updatedHouseMutation = useUpdateHouse()

  if (!isSuccess) return <ApiStatus status={status} />

  return (
    <>
      {updatedHouseMutation.isError && (
        <ValidationSummary error={updatedHouseMutation.error} />
      )}
      <Form house={data} submitted={(h) => updatedHouseMutation.mutate(h)} />
    </>
  )
}

export default HouseEdit
