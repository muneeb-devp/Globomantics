import { useAddHouse } from '../hooks/HouseHooks'
import { House } from '../types/house'
import Form from './Form'
import ValidationSummary from './ValidationSummary'

type Props = {}

const HouseAdd = (props: Props) => {
  const addHouseMutation = useAddHouse()
  const house: House = {
    id: 0,
    address: '',
    country: '',
    description: '',
    price: 0,
    photo: '',
  }

  return (
    <>
      {addHouseMutation.isError && (
        <ValidationSummary error={addHouseMutation.error} />
      )}
      <Form house={house} submitted={(h) => addHouseMutation.mutate(h)} />
    </>
  )
}

export default HouseAdd
